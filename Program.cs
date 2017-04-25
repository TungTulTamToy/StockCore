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
using Autofac;
using Autofac.Extensions.DependencyInjection;
using StockCore.Business.Repo.MongoDB;
using MongoDB.Driver;
using StockCore.DomainEntity.Data;
using StockCore.DomainEntity.Enum;
using StockCore.Business.Worker;
using StockCore.Factory;
using System.Linq;
using StockCore.Business.Repo.AppSetting;
using StockCore.Business.Builder;

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
                    .AddScoped<IFactory<string, IGetByKeyRepo<OperationStateDE,string>>, DBOperationStateRepoFactory>()                    
                    .AddScoped<IFactory<string, IGetByKeyRepo<ConsensusDE,string>>, DBConcensusRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<ShareDE,string>>, DBShareRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<StatisticDE,string>>, DBStatisticRepoFactory>()
                    .AddScoped<IFactory<string, IGetByKeyRepo<PriceDE,string>>, DBPriceRepoFactory>()
                    .AddScoped<IFactory<string, IGetByFuncRepo<string,CacheDE<StockDE>>>, DBCacheRepoFactory<StockDE>>()
                    .AddScoped<IFactory<string, IRepo<SetIndexDE>>, DBSetIndexRepoFactory>()
                    .AddScoped<IFactory<string, IRepo<QuoteGroupDE>>, DBQuoteGroupRepoFactory>()
                    .AddScoped<IFactory<string, IBuilder<string, StockDE>>, StockBuilderFactory>()
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

                //syncWeb(serviceProvider);
                //seedGroup(serviceProvider);
                //syncBackupData(serviceProvider);
                var stockInfo = getStockInfo(serviceProvider,"ptt");
            }        
            catch(Exception ex)
            {   
                Console.WriteLine(ex);
            }
        }
        private static StockDE getStockInfo(IServiceProvider serviceProvider,string quote)
        {
            StockDE stockInfo = null;
            try
            {
                var tracer=new Tracer(0,null,"Get Stock Info.");
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

            var priceTracer=new Tracer(0,null,"Start Seed Price");
            var seedPriceOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<PriceDE>>>>().Build(priceTracer);
            var consensusTracer=new Tracer(0,null,"Start Seed Consensus");
            var seedConsensusOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<ConsensusDE>>>>().Build(consensusTracer);
            var shareTracer=new Tracer(0,null,"Start Seed Share");
            var seedShareOperation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<ShareDE>>>>().Build(shareTracer);
            var statisticTracer=new Tracer(0,null,"Start Seed Price");
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
        private static IServiceProvider configureAutoFac(IServiceCollection services)
        {                
            // Create the Autofac container builder.
            var builder = new ContainerBuilder();
            // Add any Autofac modules or registrations.
            /*Attribute injector */
            /*
            builder.Register(ctx => new Interceptor.MonitorDecoratorAsync(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IServiceProvider>())).InstancePerDependency();
            builder.RegisterType<SeedQuoteGroup>().As<IOperation<IEnumerable<QuoteGroupDomainEntity>>>().InstancePerLifetimeScope().EnableInterfaceInterceptors();
            builder.RegisterType<SyncAllQuotesFromWebToDB>().As<IOperation<IEnumerable<string>>>().InstancePerLifetimeScope().EnableInterfaceInterceptors();
            builder.RegisterType<SyncQuoteFromWebToDB>().As<IOperation<string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<SetTradePriceRepository>().As<IManyReadable<PriceDomainEntity,string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<SetTradeSetIndexRepository>().As<IManyReadable<SetIndexDomainEntity,string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<SetTradeConsensusRepository>().As<IManyReadable<ConsensusDomainEntity,string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<SetTradeShareRepository>().As<IManyReadable<ShareDomainEntity,string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<SetTradeStatisticRepository>().As<IManyReadable<StatisticDomainEntity,string>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBPriceRepository>().As<IRepository<PriceDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBSetIndexRepository>().As<IRepository<SetIndexDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBConsensusRepository>().As<IRepository<ConsensusDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBShareRepository>().As<IRepository<ShareDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBStatisticRepository>().As<IRepository<StatisticDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            builder.RegisterType<MongoDBQuoteGroupRepository>().As<IRepository<QuoteGroupDomainEntity>>().InstancePerDependency().EnableInterfaceInterceptors();
            */

            //Decorator
            //builder.Register(_=>new HttpClientWrapper(new HttpClient())).As<IHttpClientWrapper>().InstancePerDependency();
            //builder.Register(ctx=>new MongoClient(ctx.Resolve<IConfigurationRoot>().GetSection("MongoConnection:ConnectionString").Value)).As<IMongoClient>().InstancePerLifetimeScope();
            
            //builder.RegisterType<ModuleGetByKey>().Named<IGetByKey<ModuleDE,string>>("ModuleRepo").SingleInstance();      
            //builder.RegisterType<MongoDatabaseWrapper>().As<IMongoDatabaseWrapper>().InstancePerLifetimeScope();
            //builder.RegisterType<DeleteOneModelBuilder>().As<IDeleteOneModelBuilder>().InstancePerDependency();
            //builder.RegisterType<ReplaceOneModelBuilder>().As<IReplaceOneModelBuilder>().InstancePerDependency();
            //builder.RegisterType<FilterDefinitionBuilderWrapper>().As<IFilterDefinitionBuilderWrapper>().InstancePerDependency();
            //builder.RegisterType<HtmlDocumentWrapper>().As<IHtmlDocumentWrapper>().InstancePerDependency();

            //builder.RegisterType<DBOperationStateRepo>().Named<IGetByKeyRepo<OperationStateDE,string>>("DBOperationStateRepo").InstancePerDependency();
            //builder.RegisterType<SyncQuoteGroup>().Named<IOperation<IEnumerable<QuoteGroupDE>>>("SyncQuoteGroup").InstancePerDependency();
            //builder.RegisterType<SyncAll>().Named<IOperation<IEnumerable<string>>>("SyncAll").InstancePerDependency();
            //builder.RegisterType<SyncQuote>().Named<IOperation<string>>("SyncQuote").InstancePerDependency();
            //builder.RegisterType<DBQuoteGroupRepo>().Named<IRepo<QuoteGroupDE>>("DBQuoteGroupRepo").InstancePerDependency();
            //builder.RegisterType<DBSetIndexRepo>().Named<IRepo<SetIndexDE>>("DBSetIndex").InstancePerDependency();              
            //builder.RegisterType<DBPriceRepo>().Named<IGetByKeyRepo<PriceDE,string>>("DBPriceRepo").InstancePerDependency();          
            //builder.RegisterType<DBConsensusRepo>().Named<IGetByKeyRepo<ConsensusDE,string>>("DBConsensusRepo").InstancePerDependency();  
            //builder.RegisterType<DBShareRepo>().Named<IGetByKeyRepo<ShareDE,string>>("DBShareRepo").InstancePerDependency();  
            //builder.RegisterType<DBStatisticRepo>().Named<IGetByKeyRepo<StatisticDE,string>>("DBStatisticRepo").InstancePerDependency();                      
            //builder.RegisterType<PriceHtmlReader>().Named<IGetByKey<IEnumerable<PriceDE>,string>>("HtmlPriceRepo").InstancePerDependency();
            //builder.RegisterType<ConsensusHtmlReader>().Named<IGetByKey<IEnumerable<ConsensusDE>,string>>("HtmlConsensusRepo").InstancePerDependency();
            //builder.RegisterType<SetIndexHtmlReader>().Named<IGetByKey<IEnumerable<SetIndexDE>,string>>("HtmlSetIndexRepo").InstancePerDependency();
            //builder.RegisterType<ShareHtmlReader>().Named<IGetByKey<IEnumerable<ShareDE>,string>>("HtmlShareRepo").InstancePerDependency();
            //builder.RegisterType<StatisticHtmlReader>().Named<IGetByKey<IEnumerable<StatisticDE>,string>>("HtmlStatisticRepo").InstancePerDependency();
            
            //builder.RegisterDecorator<IGetByKey<ModuleDE,string>>((ctx,inner) =>new ModuleConfigDec(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IConfigProvider>(),inner),"ModuleRepo").SingleInstance();
            //builder.RegisterDecorator<IGetByKeyRepo<OperationStateDE,string>>((ctx,inner) =>new BaseManyGetDBRepoDec<OperationStateDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBOperationStateRepo",inner), "DBOperationStateRepo").InstancePerDependency();
            //builder.RegisterDecorator<IOperation<IEnumerable<QuoteGroupDE>>>((ctx,inner) =>new SyncQuoteGroupDec(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),inner), "SyncQuoteGroup").InstancePerDependency();
            //builder.RegisterDecorator<IOperation<IEnumerable<string>>>((ctx,inner) =>new SyncAllDec(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),inner), "SyncAll").InstancePerDependency();
            //builder.RegisterDecorator<IOperation<string>>((ctx,inner) =>new RetrySyncQuoteDec(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),ctx.Resolve<IGetByKeyRepo<OperationStateDE,string>>(),inner), "SyncQuote").Named<IOperation<string>>("SyncQuote2").InstancePerDependency();
            //builder.RegisterDecorator<IOperation<string>>((ctx,inner) =>new SyncQuoteDec(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),inner), "SyncQuote2").InstancePerDependency();
            //builder.RegisterDecorator<IRepo<QuoteGroupDE>>((ctx,inner) =>new BaseDBRepoDec<QuoteGroupDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBQuoteGroupRepo",inner), "DBQuoteGroupRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKeyRepo<PriceDE,string>>((ctx,inner) =>new BaseManyGetDBRepoDec<PriceDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBPriceRepo",inner), "DBPriceRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKeyRepo<ConsensusDE,string>>((ctx,inner) =>new BaseManyGetDBRepoDec<ConsensusDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBConsensusRepo",inner), "DBConsensusRepo").InstancePerDependency();
            //builder.RegisterDecorator<IRepo<SetIndexDE>>((ctx,inner) =>new BaseDBRepoDec<SetIndexDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBSetIndexRepo",inner), "DBSetIndex").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKeyRepo<ShareDE,string>>((ctx,inner) =>new BaseManyGetDBRepoDec<ShareDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBShareRepo",inner), "DBShareRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKeyRepo<StatisticDE,string>>((ctx,inner) =>new BaseManyGetDBRepoDec<StatisticDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IFactory<string,IGetByKey<ModuleDE,string>>>(),"Aop.DBStatisticRepo",inner), "DBStatisticRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKey<IEnumerable<PriceDE>,string>>((ctx,inner) =>new BaseHtmlReader<PriceDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),"Aop.HtmlPriceGetByKey",inner), "HtmlPriceRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKey<IEnumerable<ConsensusDE>,string>>((ctx,inner) =>new BaseHtmlReader<ConsensusDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),"Aop.HtmlConsensusGetByKey",inner), "HtmlConsensusRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKey<IEnumerable<SetIndexDE>,string>>((ctx,inner) =>new BaseHtmlReader<SetIndexDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),"Aop.HtmlSetIndexGetByKey",inner), "HtmlSetIndexRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKey<IEnumerable<ShareDE>,string>>((ctx,inner) =>new BaseHtmlReader<ShareDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),"Aop.HtmlShareGetByKey",inner), "HtmlShareRepo").InstancePerDependency();
            //builder.RegisterDecorator<IGetByKey<IEnumerable<StatisticDE>,string>>((ctx,inner) =>new BaseHtmlReader<StatisticDE>(ctx.Resolve<ILogger<Program>>(),ctx.Resolve<IGetByKey<ModuleDE,string>>(),"Aop.HtmlStatisticGetByKey",inner), "HtmlStatisticRepo").InstancePerDependency();
            
            // Populate the services.
            builder.Populate(services);
            // Build the container.
            var container = builder.Build();

            // Create the service provider.
            var serviceProvider = new AutofacServiceProvider(container);

            //services.BuildServiceProvider();

            return serviceProvider;
        }
        private static void syncWeb(IServiceProvider serviceProvider)
        {
            try
            {
                var tracer=new Tracer(0,null,"Start Sync Web");
                var syncAllFactory = serviceProvider.GetService<IFactory<FactoryCondition,IOperation<IEnumerable<string>>>>();
                var condition = new FactoryCondition()
                {
                    SyncType = FactoryCondition.SyncAllType.AllQuote
                };
                var operation = syncAllFactory.Build(tracer);
                var quotes = Enum.GetNames(typeof(Quotes.QuotesSample2));
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
                var tracer=new Tracer(0,null,"Start Seed Group");
                var operation = serviceProvider.GetService<IFactory<string,IOperation<IEnumerable<QuoteGroupDE>>>>().Build(tracer);
                var seedGroup1 = QuoteGroupData.Sample1;
                var seedGroup2 = QuoteGroupData.Sample2;
                Task.Run(async()=> await operation.OperateAsync(seedGroup2)).GetAwaiter().GetResult();
            }        
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}