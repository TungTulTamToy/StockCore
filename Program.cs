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
using StockCore.Business.Operation.Sync;

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
                    .AddSingleton<IMongoClient>(ctx => new MongoClient(ctx.GetService<IConfigurationRoot>().GetSection("MongoConnection:ConnectionString").Value))                       

                    .AddScoped<IFactory<SyncAllFactoryCondition, IOperation<IEnumerable<string>>>, SyncAllFactory>()
                    .AddScoped<IFactory<SyncQuoteFactoryCondition, IOperation<string>>, SyncQuoteFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<QuoteGroup>>>, SyncQuoteGroupFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<Price>>>, SyncPriceFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<Consensus>>>, SyncConsensusFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<Share>>>, SyncShareFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<Statistic>>>, SyncStatisticFactory>()
                    .AddScoped<IFactory<string, IOperation<IEnumerable<SetIndex>>>, SyncSetIndexFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<Consensus>,string>>, ConsensusHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<Price>,string>>, PriceHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<SetIndex>,string>>, SetIndexHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<Share>,string>>, ShareHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKey<IEnumerable<Statistic>,string>>, StatisticHtmlReaderFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<OperationState,string>>, DBOperationStateRepoFactory>()                    
                    .AddScoped<IFactory<string, IGetByKeyRepo<Consensus,string>>, DBConsensusRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<Share,string>>, DBShareRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<Statistic,string>>, DBStatisticRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<Price,string>>, DBPriceRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<QuoteGroup,string>>, DBQuoteGroupRepoFactory>()                                        
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,StockCoreCache<Stock>>>, DBCacheRepoFactory<Stock>>()
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<QuoteGroup>>>>, DBCacheRepoFactory<IEnumerable<QuoteGroup>>>()
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<Stock>>>>, DBCacheRepoFactory<IEnumerable<Stock>>>()
                    .AddScoped<IFactory<string, IRepo<SetIndex>>, DBSetIndexRepoFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, Stock>>, StockBuilderFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, IEnumerable<QuoteGroup>>>, AllQuoteGroupBuilderFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, IEnumerable<Stock>>>, StockByGroupBuilderFactory>()

                    .AddScoped<IMongoDatabaseWrapper,MongoDatabaseWrapper>()
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

                syncBackupData(serviceProvider);
                seedGroup(serviceProvider);
                syncWeb(serviceProvider);                

                //var stockInfo = getStockInfo(serviceProvider,"ttw");
                //stockInfo = getStockInfo(serviceProvider,"ptt");
                //var groups = getAllQuoteGroup(serviceProvider);
                //var groupName = "Check";
                //var stocks = getStockByGroup(serviceProvider,groupName);

                //stockInfo = getStockInfo(serviceProvider,"ptt");
                //groups = getAllQuoteGroup(serviceProvider);
                //stocks = getStockByGroup(serviceProvider,groupName);
            }        
            catch(Exception ex)
            {   
                Console.WriteLine(ex);
            }
        }
        private static IEnumerable<Stock> getStockByGroup(IServiceProvider serviceProvider,string quoteGroupName)
        {
            IEnumerable<Stock> stocks = null;
            try
            {
                var tracer=new Tracer().Load(0,null,"Get Stock by Quote Group.",TraceSourceName.TestConsole);
                var stockByGroupBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, IEnumerable<Stock>>>>();
                var builder = stockByGroupBuilderFactory.Build(tracer);
                Task.Run(async()=>stocks = await builder.BuildAsync(quoteGroupName)).GetAwaiter().GetResult();
            }         
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }        
            return stocks;
        }
        private static IEnumerable<QuoteGroup> getAllQuoteGroup(IServiceProvider serviceProvider)
        {
            IEnumerable<QuoteGroup> groups = null;
            try
            {
                var tracer=new Tracer().Load(0,null,"Get All Quote Group.",TraceSourceName.TestConsole);
                var allQuoteGroupBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, IEnumerable<QuoteGroup>>>>();
                var builder = allQuoteGroupBuilderFactory.Build(tracer);
                Task.Run(async()=>groups = await builder.BuildAsync()).GetAwaiter().GetResult();
            }         
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }        
            return groups;
        }
        private static Stock getStockInfo(IServiceProvider serviceProvider,string quote)
        {
            Stock stockInfo = null;
            try
            {
                var tracer=new Tracer().Load(0,null,"Get Stock Info.",TraceSourceName.TestConsole);
                var stockBuilderFactory = serviceProvider.GetService<IFactory<string, IBuilder<string, Stock>>>();
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
                select new Price{Quote=backup.Quote,Close=p.Close,Date=p.Date,IsValid=true};

            var backupConsensus = from backup in sampleData
                where backup.Consensuses != null
                from c in backup.Consensuses
                where c!=null
                select new Consensus{Quote=backup.Quote,Year=c.Year,Average=c.Average,Median=c.Median,IsValid=true};

            var backupShare = from backup in sampleData
                where backup.Shares != null
                from s in backup.Shares
                where s!=null
                select new Share{Quote=backup.Quote,Amount=s.Amount,Date=s.Date,IsValid=true};

            var backupStatistic = from backup in sampleData
                where backup.Statistics != null
                from s in backup.Statistics
                where s!=null
                select new Statistic{Quote=backup.Quote,NetProfit=s.NetProfit,Year=s.Year,IsValid=true};

            var priceTracer=new Tracer().Load(0,null,"Start Seed Price",TraceSourceName.TestConsole);
            var seedPriceOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<Price>>>>().Build(priceTracer);
            var consensusTracer=new Tracer().Load(0,null,"Start Seed Consensus",TraceSourceName.TestConsole);
            var seedConsensusOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<Consensus>>>>().Build(consensusTracer);
            var shareTracer=new Tracer().Load(0,null,"Start Seed Share",TraceSourceName.TestConsole);
            var seedShareOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<Share>>>>().Build(shareTracer);
            var statisticTracer=new Tracer().Load(0,null,"Start Seed Price",TraceSourceName.TestConsole);
            var seedStatisticOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<Statistic>>>>().Build(statisticTracer);            

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
                using(var syncAllFactory = serviceProvider.GetService<IFactory<SyncAllFactoryCondition,IOperation<IEnumerable<string>>>>())
                {
                    var tracer=new Tracer().Load(0,null,"Start Sync Web",TraceSourceName.TestConsole);                    
                    var condition = new SyncAllFactoryCondition()
                    {
                        Type = SyncAllFactoryCondition.SyncType.PerQuote
                    };
                    var operation = syncAllFactory.Build(tracer);
                    var quotes = Enum.GetNames(typeof(Quotes.Ready)).Concat(Enum.GetNames(typeof(Quotes.Check)));
                    //var sampleData = BackupStockData.Sample1;
                    //var quotes = from backup in sampleData select backup.Quote;
        
                    Task.Run(async()=>await operation.OperateAsync(quotes)).GetAwaiter().GetResult();
                }
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
                var tracer=new Tracer().Load(0,null,"Start Seed Group",TraceSourceName.TestConsole);
                var operation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<QuoteGroup>>>>().Build(tracer);
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