using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using StockCore.Wrapper;
using StockCore.DomainEntity;
using StockCore.Provider;
using StockCore.Business.Repo;
using StockCore.Business.Repo.MongoDB;
using MongoDB.Driver;
using StockCore.DomainEntity.Data;
using StockCore.DomainEntity.Enum;
using StockCore.Business.Operation;
using StockCore.Factory;
using StockCore.Factory.DB;
using StockCore.Factory.Html;
using StockCore.Factory.Builder;
using StockCore.Factory.Sync;
using System.Linq;
using StockCore.Business.Repo.AppSetting;
using StockCore.Business.Builder;
using StockCore.Aop.Mon;
using static StockCore.DomainEntity.Enum.TraceSource;

namespace StockCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //setup DI
                var services = new ServiceCollection();

                services.AddLogging()
                    .AddSingleton<ILoggerFactory>(ctx=>new LoggerFactory().AddConsole(ctx.GetService<IConfigurationRoot>().GetSection("Logging")).AddDebug())
                    .AddSingleton<IConfigurationRoot>(_=>new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build())
                    .AddSingleton<ILogger>(ctx=>ctx.GetService<ILogger<Program>>())
                    .AddSingleton<IConfigProvider,StockCore.Provider.ConfigurationProvider>()
                    .AddSingleton<IConfigReader,ModuleConfigReader>()

                    .AddScoped<IFactory<FactoryCondition, IOperation<IEnumerable<string>>>, SyncAllFactory>()
                    .AddScoped<IFactory<string, IOperation<string>>, SyncQuoteFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<QuoteGroupDE>>>, SyncQuoteGroupFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<PriceDE>>>, SyncPriceFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<ConsensusDE>>>, SyncConcensusFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<ShareDE>>>, SyncShareFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<StatisticDE>>>, SyncStatisticFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<ConsensusDE>,string>>, ConsensusHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<PriceDE>,string>>, PriceHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<SetIndexDE>,string>>, SetIndexHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<ShareDE>,string>>, ShareHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<StatisticDE>,string>>, StatisticHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<OperationState,string>>, DBOperationStateRepoFactory>()                    
                    .AddScoped<IFactory<string, IGetByKeyRepo<ConsensusDE,string>>, DBConcensusRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<ShareDE,string>>, DBShareRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<StatisticDE,string>>, DBStatisticRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<PriceDE,string>>, DBPriceRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<QuoteGroupDE,string>>, DBQuoteGroupRepoFactory>()                                        
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,CacheDE<StockDE>>>, DBCacheRepoFactory<StockDE>>()
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<QuoteGroupDE>>>>, DBCacheRepoFactory<DECollection<QuoteGroupDE>>>()
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<StockDE>>>>, DBCacheRepoFactory<DECollection<StockDE>>>()
                    .AddScoped<IFactory<string, IRepo<SetIndexDE>>, DBSetIndexRepoFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, StockDE>>, StockBuilderFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, DECollection<QuoteGroupDE>>>, AllQuoteGroupBuilderFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, DECollection<StockDE>>>, StockByGroupBuilderFactory>()
                    .AddScoped<IMongoDatabaseWrapper,MongoDatabaseWrapper>()
                    .AddScoped<IMongoClient>(ctx => new MongoClient(ctx.GetService<IConfigurationRoot>().GetSection("MongoConnection:ConnectionString").Value))    

                    .AddTransient<IDeleteOneModelBuilder,DeleteOneModelBuilder>()
                    .AddTransient<IReplaceOneModelBuilder,ReplaceOneModelBuilder>()
                    .AddTransient<IFilterDefinitionBuilderWrapper,FilterDefinitionBuilderWrapper>()
                    .AddTransient<IHtmlDocumentWrapper,HtmlDocumentWrapper>()
                    .AddTransient<IHttpClientWrapper>(_=> new HttpClientWrapper(new HttpClient()));
                
                //var serviceProvider = configureAutoFac(services);
                var serviceProvider = services.BuildServiceProvider();

                /*Test logger by default DI */
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogDebug("Start application");

                syncWeb(serviceProvider);
                seedGroup(serviceProvider);
                syncBackupData(serviceProvider);

                var stockInfo = getStockInfo(serviceProvider,"ptt");
                stockInfo = getStockInfo(serviceProvider,"work");
                var groups = getAllQuoteGroup(serviceProvider);
                var groupName = "Check";
                var stocks = getStockByGroup(serviceProvider,groupName);

                stockInfo = getStockInfo(serviceProvider,"ptt");
                groups = getAllQuoteGroup(serviceProvider);
                stocks = getStockByGroup(serviceProvider,groupName);
            }        
            catch(Exception ex)
            {   
                Console.WriteLine(ex);
            }
        }
        private static DECollection<StockDE> getStockByGroup(IServiceProvider serviceProvider,string quoteGroupName)
        {
            DECollection<StockDE> stocks = null;
            try
            {
                var tracer=new Tracer(0,null,"Get Stock by Quote Group.",TraceSourceName.TestConsole);
                var stockByGroupBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, DECollection<StockDE>>>>();
                var builder = stockByGroupBuilderFactory.Build(tracer);
                Task.Run(async()=>stocks = await builder.BuildAsync(quoteGroupName)).GetAwaiter().GetResult();
            }         
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }        
            return stocks;
        }
        private static DECollection<QuoteGroupDE> getAllQuoteGroup(IServiceProvider serviceProvider)
        {
            DECollection<QuoteGroupDE> groups = null;
            try
            {
                var tracer=new Tracer(0,null,"Get All Quote Group.",TraceSourceName.TestConsole);
                var allQuoteGroupBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, DECollection<QuoteGroupDE>>>>();
                var builder = allQuoteGroupBuilderFactory.Build(tracer);
                Task.Run(async()=>groups = await builder.BuildAsync()).GetAwaiter().GetResult();
            }         
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }        
            return groups;
        }
        private static StockDE getStockInfo(IServiceProvider serviceProvider,string quote)
        {
            StockDE stockInfo = null;
            try
            {
                var tracer=new Tracer(0,null,"Get Stock Info.",TraceSourceName.TestConsole);
                var stockBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, StockDE>>>();
                var builder = stockBuilderFactory.Build(tracer);
                Task.Run(async()=>stockInfo = await builder.BuildAsync(quote)).GetAwaiter().GetResult();
            }         
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }        
            return stockInfo;
        }
        private static void syncBackupData(IServiceProvider serviceProvider)
        {
            var sampleData = BackupStockData.Sample1;

            var backupPrice = from backup in sampleData
                where backup.Prices != null
                from p in backup.Prices
                select new PriceDE{Quote=backup.Quote,Close=p.Close,Date=p.Date,IsValid=true};

            var backupConsensus = from backup in sampleData
                where backup.Consensuses != null
                from c in backup.Consensuses
                where c!=null
                select new ConsensusDE{Quote=backup.Quote,Year=c.Year,Average=c.Average,Median=c.Median,IsValid=true};

            var backupShare = from backup in sampleData
                where backup.Shares != null
                from s in backup.Shares
                where s!=null
                select new ShareDE{Quote=backup.Quote,Amount=s.Amount,Date=s.Date,IsValid=true};

            var backupStatistic = from backup in sampleData
                where backup.Statistics != null
                from s in backup.Statistics
                where s!=null
                select new StatisticDE{Quote=backup.Quote,NetProfit=s.NetProfit,Year=s.Year,IsValid=true};

            var priceTracer=new Tracer(0,null,"Start Seed Price",TraceSourceName.TestConsole);
            var seedPriceOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<PriceDE>>>>().Build(priceTracer);
            var consensusTracer=new Tracer(0,null,"Start Seed Consensus",TraceSourceName.TestConsole);
            var seedConsensusOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<ConsensusDE>>>>().Build(consensusTracer);
            var shareTracer=new Tracer(0,null,"Start Seed Share",TraceSourceName.TestConsole);
            var seedShareOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<ShareDE>>>>().Build(shareTracer);
            var statisticTracer=new Tracer(0,null,"Start Seed Price",TraceSourceName.TestConsole);
            var seedStatisticOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<StatisticDE>>>>().Build(statisticTracer);            

            Task.Run(async()=> {
                var seedPriceTask = seedPriceOperation.OperateAsync(backupPrice);
                var seedConsensusTask = seedConsensusOperation.OperateAsync(backupConsensus);
                var seedShareTask = seedShareOperation.OperateAsync(backupShare);
                var seedStatisticTask = seedStatisticOperation.OperateAsync(backupStatistic);

                await seedPriceTask;
                await seedConsensusTask;
                await seedShareTask;
                await seedStatisticTask;
            }).GetAwaiter().GetResult();
        }
        private static void syncWeb(IServiceProvider serviceProvider)
        {
            try
            {
                var tracer=new Tracer(0,null,"Start Sync Web",TraceSourceName.TestConsole);
                var syncAllFactory = serviceProvider.GetService<IFactory<FactoryCondition,IOperation<IEnumerable<string>>>>();
                var condition = new FactoryCondition()
                {
                    SyncType = FactoryCondition.SyncAllType.AllQuote
                };
                var operation = syncAllFactory.Build(tracer);
                var quotes = Enum.GetNames(typeof(Quotes.Ready));
                var sampleData = BackupStockData.Sample1;
                //var quotes = from backup in sampleData select backup.Quote;
    
                Task.Run(async()=>await operation.OperateAsync(quotes)).GetAwaiter().GetResult();
            }        
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void seedGroup(IServiceProvider serviceProvider)
        {
            try
            {
                var tracer=new Tracer(0,null,"Start Seed Group",TraceSourceName.TestConsole);
                var operation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<QuoteGroupDE>>>>().Build(tracer);
                var seedGroup = QuoteGroupData.PrepareData;
                Task.Run(async()=> await operation.OperateAsync(seedGroup)).GetAwaiter().GetResult();
            }        
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}