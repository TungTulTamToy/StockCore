using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity.Data
{
    public class BackupStockData
    {
        public static IEnumerable<BackupStockDE> Sample1
        {
            get
            {
                return new List<BackupStockDE>()
                {
                    new BackupStockDE()
                    {
                        Quote = "ptt",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=276,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=341,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=334,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=335,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=223,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=160,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=94652,Year=2013},
                            new StatisticDE{NetProfit=104666,Year=2012},
                            new StatisticDE{NetProfit=105296.41,Year=2011},
                            new StatisticDE{NetProfit=83087,Year=2010},
                            new StatisticDE{NetProfit=59547.59,Year=2009},
                            new StatisticDE{NetProfit=51704.8,Year=2008},
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2856299625,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2856299625,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2856299625,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2849042025,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2833785000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=2824057000,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "work",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE{Close=22.2,Date=new DateTime(2014,1,1)},
                            new PriceDE{Close=48.25,Date=new DateTime(2013,1,1)},
                            new PriceDE{Close=13.9,Date=new DateTime(2012,1,1)},
                            new PriceDE{Close=12.1,Date=new DateTime(2011,1,1)},
                            new PriceDE{Close=6.8,Date=new DateTime(2010,1,1)},
                            new PriceDE{Close=4.7,Date=new DateTime(2009,1,1)}
                        },
                            Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=256.78,Year=2013},
                            new StatisticDE{NetProfit=404,Year=2012},
                            new StatisticDE{NetProfit=327.352,Year=2011},
                            new StatisticDE{NetProfit=186.87,Year=2010},
                            new StatisticDE{NetProfit=73.13,Year=2009},
                            new StatisticDE{NetProfit=162.06,Year=2008},
                        },
                            Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=257107972,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=257107972,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=250250000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=200000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=200000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=200000000,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "earth",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE{Close=6.1,Date=new DateTime(2014,1,1)},
                            new PriceDE{Close=8.25,Date=new DateTime(2013,1,1)},
                            new PriceDE{Close=4.2,Date=new DateTime(2012,1,1)},
                            new PriceDE{Close=2.04,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1110.6,Year=2013},
                            new StatisticDE{NetProfit=1280.44,Year=2012},
                            new StatisticDE{NetProfit=395.31,Year=2011},
                            new StatisticDE{NetProfit=70.78,Year=2010}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2949088091,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2605495683,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2554299239,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2554299239,Date=new DateTime(2010,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.49,Median=0.49,Year=2015},
                            new ConsensusDE{Average=0.52,Median=0.52,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "banpu",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE{Close=26.5,Date=new DateTime(2014,1,1)},
                            new PriceDE{Close=388,Date=new DateTime(2013,1,1)},
                            new PriceDE{Close=700.7,Date=new DateTime(2012,1,1)},
                            new PriceDE{Close=723.28,Date=new DateTime(2011,1,1)},
                            new PriceDE{Close=509.2,Date=new DateTime(2010,1,1)},
                            new PriceDE{Close=207.14,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=3151,Year=2013},
                            new StatisticDE{NetProfit=9293.2,Year=2012},
                            new StatisticDE{NetProfit=20059.83,Year=2011},
                            new StatisticDE{NetProfit=24727.72,Year=2010},
                            new StatisticDE{NetProfit=14229.13,Year=2009},
                            new StatisticDE{NetProfit=9227.67,Year=2008},
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2581878550,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=271747855,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=271747855,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=271747855,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=271747855,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=271747855,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "gunkul",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=12.3,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=17,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=10.91,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=4.61,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=882.9,Year=2013},
                            new StatisticDE{NetProfit=779.56,Year=2012},
                            new StatisticDE{NetProfit=89.52,Year=2011},
                            new StatisticDE{NetProfit=123.18,Year=2010}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=660000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=440000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=400000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=400000000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ivl",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=20.7,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=26.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=32,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=39,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=9.43,Date=new DateTime(2010,1,1)},
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1325.87,Year=2013},
                            new StatisticDE{NetProfit=4611,Year=2012},
                            new StatisticDE{NetProfit=15567.97,Year=2011},
                            new StatisticDE{NetProfit=10560.44,Year=2010},
                            new StatisticDE{NetProfit=4824,Year=2009},
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=4814257245,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=4814257245,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=4814257245,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=4814257245,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=4814257245,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ptl",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=8.8,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=12.1,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=15.9,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=22.8,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=6.85,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=3.98,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=3.72,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=5.96,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=-479.72,Year=2013},
                            new StatisticDE{NetProfit=373.97,Year=2012},
                            new StatisticDE{NetProfit=1361.68,Year=2011},
                            new StatisticDE{NetProfit=3882.88,Year=2010},
                            new StatisticDE{NetProfit=1039.39,Year=2009},
                            new StatisticDE{NetProfit=1041.97,Year=2008},
                            new StatisticDE{NetProfit=813.55,Year=2007},
                            new StatisticDE{NetProfit=341.84,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=800000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=800000000,Date=new DateTime(2006,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.4125,Median=0.4125,Year=2015},
                            new ConsensusDE{Average=0.375,Median=0.375,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aj",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=8.85,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=16.6,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=16.6,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=25.68,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=3.41,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=2.53,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=1.87,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=-97.98,Year=2013},
                            new StatisticDE{NetProfit=190,Year=2012},
                            new StatisticDE{NetProfit=878.6,Year=2011},
                            new StatisticDE{NetProfit=984.92,Year=2010},
                            new StatisticDE{NetProfit=288.05,Year=2009},
                            new StatisticDE{NetProfit=160.31,Year=2008},
                            new StatisticDE{NetProfit=129.64,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=399439227,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=399439227,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.52573705,Median=0.52573705,Year=2015},
                            new ConsensusDE{Average=0.47566685,Median=0.47566685,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "vnt",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=10.7,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=20.4,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=17.61,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=11.55,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=6.05,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=3.16,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=5.77,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=198.17,Year=2013},
                            new StatisticDE{NetProfit=1682.89,Year=2012},
                            new StatisticDE{NetProfit=1989.25,Year=2011},
                            new StatisticDE{NetProfit=1508.08,Year=2010},
                            new StatisticDE{NetProfit=985.25,Year=2009},
                            new StatisticDE{NetProfit=1034.81,Year=2008},
                            new StatisticDE{NetProfit=654.48,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1185193444,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1185193444,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bcp",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=26.75,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=36,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=19.64,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=16.84,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=12.76,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=5.81,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=10.19,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=4652.92,Year=2013},
                            new StatisticDE{NetProfit=4272.56,Year=2012},
                            new StatisticDE{NetProfit=5610.16,Year=2011},
                            new StatisticDE{NetProfit=2812.81,Year=2010},
                            new StatisticDE{NetProfit=7524.26,Year=2009},
                            new StatisticDE{NetProfit=-750.09,Year=2008},
                            new StatisticDE{NetProfit=1763.76,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1376923157,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1376923157,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1376923157,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1372170011,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1372170011,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1372170011,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1372170011,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "pttep",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=153,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=166,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=174.51,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=160.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=132,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=99,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=147,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=93,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=56154.77,Year=2013},
                            new StatisticDE{NetProfit=57315.96,Year=2012},
                            new StatisticDE{NetProfit=44748,Year=2011},
                            new StatisticDE{NetProfit=41739,Year=2010},
                            new StatisticDE{NetProfit=22153.6,Year=2009},
                            new StatisticDE{NetProfit=41674.84,Year=2008},
                            new StatisticDE{NetProfit=28455.39,Year=2007},
                            new StatisticDE{NetProfit=28047.27,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=3969985400,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=3969985400,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=3319985400,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=3318433600,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=3312560000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=3307080000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=3297420000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=3286000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "pttgc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=71.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=80,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=65.45,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=37,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=24.7,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=9.8,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=33277.41,Year=2013},
                            new StatisticDE{NetProfit=34001.27,Year=2012},
                            new StatisticDE{NetProfit=30033,Year=2011},
                            new StatisticDE{NetProfit=6342.88,Year=2010},
                            new StatisticDE{NetProfit=9161.56,Year=2009},
                            new StatisticDE{NetProfit=-8464.66,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=4508849117,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=4507624281,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=4506643000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2979106161,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2967072148,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=2967072148,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "scc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=406,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=444,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=339.93,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=312,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=217,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=102,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=204,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=232,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=36522.25,Year=2013},
                            new StatisticDE{NetProfit=23579.99,Year=2012},
                            new StatisticDE{NetProfit=27280.66,Year=2011},
                            new StatisticDE{NetProfit=37382,Year=2010},
                            new StatisticDE{NetProfit=24345.5,Year=2009},
                            new StatisticDE{NetProfit=16770.61,Year=2008},
                            new StatisticDE{NetProfit=30351.9,Year=2007},
                            new StatisticDE{NetProfit=29450.69,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1200000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "kce",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=22.8,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=10.4,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=4.84,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=7.4,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=5.25,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=0.91,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=3.36,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=2.79,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1173.5,Year=2013},
                            new StatisticDE{NetProfit=712.33,Year=2012},
                            new StatisticDE{NetProfit=132.02,Year=2011},
                            new StatisticDE{NetProfit=535,Year=2010},
                            new StatisticDE{NetProfit=171.55,Year=2009},
                            new StatisticDE{NetProfit=-399.17,Year=2008},
                            new StatisticDE{NetProfit=257.43,Year=2007},
                            new StatisticDE{NetProfit=-116.35,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=474995769,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=472600769,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=464053000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=471067269,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=462500000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=462500000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=462500000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=314930000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hana",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=24.8,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=24.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=17.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=25.25,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=21,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=11,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=19,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=24.4,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=2337.2,Year=2013},
                            new StatisticDE{NetProfit=1661,Year=2012},
                            new StatisticDE{NetProfit=1618.07,Year=2011},
                            new StatisticDE{NetProfit=2749,Year=2010},
                            new StatisticDE{NetProfit=2042.96,Year=2009},
                            new StatisticDE{NetProfit=1909.55,Year=2008},
                            new StatisticDE{NetProfit=2449.16,Year=2007},
                            new StatisticDE{NetProfit=2216.2,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=804878860,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=804878860,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "delta",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=53,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=35.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=20.33,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=28.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=15.17,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=7.41,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=15.14,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=11.69,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=5415.69,Year=2013},
                            new StatisticDE{NetProfit=4347.38,Year=2012},
                            new StatisticDE{NetProfit=2864.33,Year=2011},
                            new StatisticDE{NetProfit=4152.57,Year=2010},
                            new StatisticDE{NetProfit=2189.38,Year=2009},
                            new StatisticDE{NetProfit=2897.48,Year=2008},
                            new StatisticDE{NetProfit=3155.42,Year=2007},
                            new StatisticDE{NetProfit=1961.71,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1247381614,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=1247381614,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "advanc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=209,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=210,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=147.85,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=80,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=83,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=75,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=93.5,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=73,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=36274.13,Year=2013},
                            new StatisticDE{NetProfit=34883.23,Year=2012},
                            new StatisticDE{NetProfit=22217.71,Year=2011},
                            new StatisticDE{NetProfit=20547,Year=2010},
                            new StatisticDE{NetProfit=17055.37,Year=2009},
                            new StatisticDE{NetProfit=16409.04,Year=2008},
                            new StatisticDE{NetProfit=16290.47,Year=2007},
                            new StatisticDE{NetProfit=16256.02,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2973095330,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2973095330,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2973095330,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2968527952,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2965440000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=2961740000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=2958120000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=2953550000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "dtac",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=95.75,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=86.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=66,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=40.25,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=32.25,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=29.5,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=39.25,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=10569.38,Year=2013},
                            new StatisticDE{NetProfit=11278.08,Year=2012},
                            new StatisticDE{NetProfit=11812.85,Year=2011},
                            new StatisticDE{NetProfit=10892,Year=2010},
                            new StatisticDE{NetProfit=6627.77,Year=2009},
                            new StatisticDE{NetProfit=9329.1,Year=2008},
                            new StatisticDE{NetProfit=5841.42,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2367811000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=2367811000,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "jas",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=7.05,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=6,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=2.02,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=1.8,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=0.45,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=0.36,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=3002.51,Year=2013},
                            new StatisticDE{NetProfit=2136.5,Year=2012},
                            new StatisticDE{NetProfit=1072.498,Year=2011},
                            new StatisticDE{NetProfit=663.29,Year=2010},
                            new StatisticDE{NetProfit=203.52,Year=2009},
                            new StatisticDE{NetProfit=-1244.92,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=7137394378,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=7137394378,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=7244000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=7244000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=7244000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=7244000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bland",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=1.43,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=1.7,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=0.71,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=0.62,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=0.52,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=0.23,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=2337.87,Year=2013},
                            new StatisticDE{NetProfit=621.2,Year=2012},
                            new StatisticDE{NetProfit=789.55,Year=2011},
                            new StatisticDE{NetProfit=528.65,Year=2010},
                            new StatisticDE{NetProfit=1746.28,Year=2009},
                            new StatisticDE{NetProfit=6022.72,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=18012968488,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=17795295397,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=17795295397,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=17795295397,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=17795295397,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=17795295397,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "sc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=2.98,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=30.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=14.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=8.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=5.25,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=3.05,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1081.62,Year=2013},
                            new StatisticDE{NetProfit=1108,Year=2012},
                            new StatisticDE{NetProfit=1079.31,Year=2011},
                            new StatisticDE{NetProfit=1152.32,Year=2010},
                            new StatisticDE{NetProfit=764.01,Year=2009},
                            new StatisticDE{NetProfit=650.31,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=3298425000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=658640200,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=658640200,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=658640200,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=658640200,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=658640200,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "lh",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=8.6,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=11.3,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=6.4,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=5.55,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=5.45,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=6478.4,Year=2013},
                            new StatisticDE{NetProfit=5635.73,Year=2012},
                            new StatisticDE{NetProfit=5608.56,Year=2011},
                            new StatisticDE{NetProfit=3971.16,Year=2010},
                            new StatisticDE{NetProfit=3908.47,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=10025921523,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=10025921523,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=10025921523,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=10025921523,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=10025921523,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "siri",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=1.81,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=4.14,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=1.85,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=5.4,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.36,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.78,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=3.48,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=2.96,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1929.67,Year=2013},
                            new StatisticDE{NetProfit=2947,Year=2012},
                            new StatisticDE{NetProfit=2015.08,Year=2011},
                            new StatisticDE{NetProfit=1897.73,Year=2010},
                            new StatisticDE{NetProfit=1607.54,Year=2009},
                            new StatisticDE{NetProfit=913.61,Year=2008},
                            new StatisticDE{NetProfit=707.93,Year=2007},
                            new StatisticDE{NetProfit=404.25,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=9099155119,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=8364454765,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=7150071000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1505959692,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1486328692,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1486328692,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1486328692,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=1486328692,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "prin",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=1.34,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=2.22,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=1.39,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=2,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=1.85,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=0.71,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=2.73,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=2.94,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=191.8,Year=2013},
                            new StatisticDE{NetProfit=354,Year=2012},
                            new StatisticDE{NetProfit=203.05,Year=2011},
                            new StatisticDE{NetProfit=573,Year=2010},
                            new StatisticDE{NetProfit=483.89,Year=2009},
                            new StatisticDE{NetProfit=315.56,Year=2008},
                            new StatisticDE{NetProfit=77.98,Year=2007},
                            new StatisticDE{NetProfit=447.8,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1219303655,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1219303655,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1216041855,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1105499456,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1005000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1005000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1005000000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=670000000,Date=new DateTime(2006,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.17,Median=0.17,Year=2015},
                            new ConsensusDE{Average=0.07,Median=0.07,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpn",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=37.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=86,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=6292.53,Year=2013},
                            new StatisticDE{NetProfit=6188.7,Year=2012}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=4357632000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2178816000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "smit",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=4.72,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=5.1,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=3.44,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=2.66,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=1.44,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.36,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=2.06,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=1.88,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=264.16,Year=2013},
                            new StatisticDE{NetProfit=303.21,Year=2012},
                            new StatisticDE{NetProfit=221.84,Year=2011},
                            new StatisticDE{NetProfit=200.25,Year=2010},
                            new StatisticDE{NetProfit=40.13,Year=2009},
                            new StatisticDE{NetProfit=142.61,Year=2008},
                            new StatisticDE{NetProfit=166.43,Year=2007},
                            new StatisticDE{NetProfit=161.14,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=530000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=530000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=520384000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=526252700,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=526252700,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=526252700,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=526252700,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=526252700,Date=new DateTime(2006,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.54,Median=0.54,Year=2015},
                            new ConsensusDE{Average=0.46,Median=0.46,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mcs",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=4.14,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=6.95,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=9.16,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=9.68,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=3.7,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.51,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=2.49,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=393.11,Year=2013},
                            new StatisticDE{NetProfit=164.95,Year=2012},
                            new StatisticDE{NetProfit=476.31,Year=2011},
                            new StatisticDE{NetProfit=810.97,Year=2010},
                            new StatisticDE{NetProfit=576.26,Year=2009},
                            new StatisticDE{NetProfit=353.52,Year=2008},
                            new StatisticDE{NetProfit=328.94,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=500000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=500000000,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "snc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=15,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=24.8,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=23.45,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=19.11,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.94,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=3.04,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=7.88,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=423.21,Year=2013},
                            new StatisticDE{NetProfit=493.81,Year=2012},
                            new StatisticDE{NetProfit=519.74,Year=2011},
                            new StatisticDE{NetProfit=381.32,Year=2010},
                            new StatisticDE{NetProfit=138.72,Year=2009},
                            new StatisticDE{NetProfit=98.71,Year=2008},
                            new StatisticDE{NetProfit=206.13,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=287777339,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=287777339,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=1.44,Median=1.44,Year=2015},
                            new ConsensusDE{Average=1.21,Median=1.21,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bjchi",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=37.75,Date=new DateTime(2014,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1206.3,Year=2013}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=320000000,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bwg",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=2.2,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=1.98,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=1.65,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=1.22,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=1.08,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.36,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=4.29,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=163.2,Year=2013},
                            new StatisticDE{NetProfit=75.85,Year=2012},
                            new StatisticDE{NetProfit=97.4,Year=2011},
                            new StatisticDE{NetProfit=41.03,Year=2010},
                            new StatisticDE{NetProfit=-43.82,Year=2009},
                            new StatisticDE{NetProfit=73.65,Year=2008},
                            new StatisticDE{NetProfit=106.86,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=714255819,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=714255819,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=714245000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=640000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=640000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=640000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=640000000,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.41,Median=0.41,Year=2015},
                            new ConsensusDE{Average=0.36,Median=0.36,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bec",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=46.75,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=73.75,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=43.25,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=31.5,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=5589.48,Year=2013},
                            new StatisticDE{NetProfit=4777.25,Year=2012},
                            new StatisticDE{NetProfit=3530.35,Year=2011},
                            new StatisticDE{NetProfit=3302.29,Year=2010}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2000000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2000000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2000000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2000000000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpf",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=28.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=35.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=35,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=21.9,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=11.5,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=24.18,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=24.08,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=5.45,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=7065.25,Year=2013},
                            new StatisticDE{NetProfit=18790,Year=2012},
                            new StatisticDE{NetProfit=15837.01,Year=2011},
                            new StatisticDE{NetProfit=13837,Year=2010},
                            new StatisticDE{NetProfit=10190.22,Year=2009},
                            new StatisticDE{NetProfit=3128.4,Year=2008},
                            new StatisticDE{NetProfit=1275.13,Year=2007},
                            new StatisticDE{NetProfit=2510.33,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=7742941932,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=7742941932,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=7742941932,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=7048937826,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=7048937826,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=7048937826,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=7048937826,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bla",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=61.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=69.75,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=49,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=28.21,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=21.93,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=4380.5,Year=2013},
                            new StatisticDE{NetProfit=3284.37,Year=2012},
                            new StatisticDE{NetProfit=3417.1,Year=2011},
                            new StatisticDE{NetProfit=2796.48,Year=2010},
                            new StatisticDE{NetProfit=1185.69,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1210801300,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1207399800,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1200000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "scb",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=149,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=179,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=119,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=94,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=79.75,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=52,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=76,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=50232.79,Year=2013},
                            new StatisticDE{NetProfit=40219.9,Year=2012},
                            new StatisticDE{NetProfit=36273,Year=2011},
                            new StatisticDE{NetProfit=24206,Year=2010},
                            new StatisticDE{NetProfit=20759.72,Year=2009},
                            new StatisticDE{NetProfit=21413.7,Year=2008},
                            new StatisticDE{NetProfit=17355.96,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=3393736429,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=3393808197,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=3393348537,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=3392728306,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=3392728306,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=3392728306,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=3392728306,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bbl",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=171.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=209,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=153.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=150.75,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=106.62,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=66.7,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=106.07,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=35905.56,Year=2013},
                            new StatisticDE{NetProfit=33021.46,Year=2012},
                            new StatisticDE{NetProfit=27337.64,Year=2011},
                            new StatisticDE{NetProfit=24593.42,Year=2010},
                            new StatisticDE{NetProfit=20764.04,Year=2009},
                            new StatisticDE{NetProfit=20242.99,Year=2008},
                            new StatisticDE{NetProfit=19217.88,Year=2007}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1908842894,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=1908842894,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ifs",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=2.54,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=2.96,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=1.25,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=1.32,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=125.08,Year=2013},
                            new StatisticDE{NetProfit=111.71,Year=2012},
                            new StatisticDE{NetProfit=67.84,Year=2011},
                            new StatisticDE{NetProfit=84.8,Year=2010}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=470000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=470000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=470000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=470000000,Date=new DateTime(2010,1,31)}
                        },
                        Consensuses = new ConsensusDE[] 
                        { 
                            new ConsensusDE{Average=0.33,Median=0.33,Year=2015},
                            new ConsensusDE{Average=0.29,Median=0.29,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ttw",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=9.65,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=10.3,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=5.36,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=6.15,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.34,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=4.32,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=2573.76,Year=2013},
                            new StatisticDE{NetProfit=2421.32,Year=2012},
                            new StatisticDE{NetProfit=2112.97,Year=2011},
                            new StatisticDE{NetProfit=2063,Year=2010},
                            new StatisticDE{NetProfit=1593.63,Year=2009},
                            new StatisticDE{NetProfit=1358.41,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=3990000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=3990000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=3990000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=3990000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=3990000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=3990000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "singer",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=16.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=19.8,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=6.7,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=3.44,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=1.54,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=320.57,Year=2013},
                            new StatisticDE{NetProfit=226.22,Year=2012},
                            new StatisticDE{NetProfit=142.46,Year=2011},
                            new StatisticDE{NetProfit=89.37,Year=2010},
                            new StatisticDE{NetProfit=36.53,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=270000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=270000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=270000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=270000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=270000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hmpro",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=7.48,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=13.8,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=11.2,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=7.02,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=2.93,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.17,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=1.51,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=1.77,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=3068.48,Year=2013},
                            new StatisticDE{NetProfit=2679.47,Year=2012},
                            new StatisticDE{NetProfit=2005.36,Year=2011},
                            new StatisticDE{NetProfit=1638,Year=2010},
                            new StatisticDE{NetProfit=1142,Year=2009},
                            new StatisticDE{NetProfit=959,Year=2008},
                            new StatisticDE{NetProfit=710,Year=2007},
                            new StatisticDE{NetProfit=608,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=7044132922,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=7041430018,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=5836700000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=4355000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=4355000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=4355000000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=4355000000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=4355000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "sta",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=12.3,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=18.6,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=21.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=31.79,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.42,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=1.41,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=1811.6,Year=2013},
                            new StatisticDE{NetProfit=1378.89,Year=2012},
                            new StatisticDE{NetProfit=1306.249,Year=2011},
                            new StatisticDE{NetProfit=3852.72,Year=2010},
                            new StatisticDE{NetProfit=2141.99,Year=2009},
                            new StatisticDE{NetProfit=627.26,Year=2008}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1280000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1280000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1280000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1280000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1280000000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=1280000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "tvo",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=19.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=25.75,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=19.4,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=28,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=16.8,Date=new DateTime(2010,1,1)},
                            new PriceDE {Close=9.85,Date=new DateTime(2009,1,1)},
                            new PriceDE {Close=15.7,Date=new DateTime(2008,1,1)},
                            new PriceDE {Close=6.44,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=959.12,Year=2013},
                            new StatisticDE{NetProfit=1775.31,Year=2012},
                            new StatisticDE{NetProfit=725.3,Year=2011},
                            new StatisticDE{NetProfit=1524.94,Year=2010},
                            new StatisticDE{NetProfit=1624.52,Year=2009},
                            new StatisticDE{NetProfit=749.63,Year=2008},
                            new StatisticDE{NetProfit=1256.39,Year=2007},
                            new StatisticDE{NetProfit=471.36,Year=2006}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=808610985,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=808610985,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=768753874,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=765404049,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=692500000,Date=new DateTime(2009,1,31)},
                            new ShareDE{Amount=624510000,Date=new DateTime(2008,1,31)},
                            new ShareDE{Amount=624510000,Date=new DateTime(2007,1,31)},
                            new ShareDE{Amount=499610000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "jubile",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=22.6,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=23,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=11.1,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=6.9,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=2.8,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=202.8,Year=2013},
                            new StatisticDE{NetProfit=165.87,Year=2012},
                            new StatisticDE{NetProfit=131.19,Year=2011},
                            new StatisticDE{NetProfit=103.73,Year=2010},
                            new StatisticDE{NetProfit=60.24,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=173300000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=173300000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=172290000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=171120000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=170000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ait",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=25.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=67.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=52,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=43,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=25.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=567.62,Year=2013},
                            new StatisticDE{NetProfit=367.59,Year=2012},
                            new StatisticDE{NetProfit=438.92,Year=2011},
                            new StatisticDE{NetProfit=388.37,Year=2010},
                            new StatisticDE{NetProfit=312.21,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=206320897,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=68773630,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=68773630,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=68773630,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=68773630,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "m",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=48.75,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=47,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=2039.17,Year=2013},
                            new StatisticDE{NetProfit=2041,Year=2012}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=906850000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=906850000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hotpot",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=3.16,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=3.92,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=42.78,Year=2013},
                            new StatisticDE{NetProfit=23.33,Year=2012}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=406000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=406000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bdms",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=118,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=133,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=76.75,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=48,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=23.8,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new StatisticDE[]
                        {
                            new StatisticDE{NetProfit=6261.46,Year=2013},
                            new StatisticDE{NetProfit=7936.95,Year=2012},
                            new StatisticDE{NetProfit=4385.99,Year=2011},
                            new StatisticDE{NetProfit=2295.06,Year=2010},
                            new StatisticDE{NetProfit=1725.18,Year=2009}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1545458883,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1545460000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1545460000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1246040000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1214500000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "true",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=6.37,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=5.84,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=2.85,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=3.92,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=1.71,Date=new DateTime(2010,1,1)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "rs",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=7.35,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=7.35,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=2.74,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=3.2,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=2,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=953870000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=882690000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=882650000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=708070000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=708070000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "intuch",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=70.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=68.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=50,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=28.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=26.25,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=3206420305,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=3206420305,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=3206420305,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=3201080000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=3201080000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpall",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=39.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=47.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=28.25,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=19.25,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=11.4,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=8983101348,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=8983101348,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=4493150000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=4493150000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=4493150000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "makro",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=31.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=22.3,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=12.8,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=7.1,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.3,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=4800000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=4800000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=4800000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=4800000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=4800000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "grammy",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=16.6,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=16.59,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=16.97,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=13.78,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=12.75,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=636317936,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=530260000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=530260000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=530260000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=530260000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mcot",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=28.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=46.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=27.75,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=29,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=22.4,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=687099210,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=687099210,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=687099210,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=687099210,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=687099210,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "top",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=52,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=75.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=64.25,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=69.75,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=40.75,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2040027873,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2040027873,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2040027873,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2040027873,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2040027873,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aav",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=3.56,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=6.1,Date=new DateTime(2013,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=4850000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=4850000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "nok",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=17.6,Date=new DateTime(2014,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=625000000,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "kbank",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=171,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=197.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=129,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=118.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=82.5,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=2393260193,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=2393260193,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=2393260193,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=2393260193,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=2393260193,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bay",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=32.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=33.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=22.2,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=25.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=19.5,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=6074143747,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=6074143747,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=6074143747,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=6074143747,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=6074143747,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "samart",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=14.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=13.7,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=8.05,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=9,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=5.55,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1006503910,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1002100000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=990650000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=985630000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=980310000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "thcom",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=37.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=23.8,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=12.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=5.65,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=6.75,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1095937540,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1095937540,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1095937540,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1095937540,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1095937540,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "gfpt",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=13.1,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=8.4,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=10.9,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=8.1,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=4.08,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1253821000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1253821000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1253821000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1253821000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1253821000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "lpn",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=14.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=22,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=13.9,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=8.7,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=6.6,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1475698768,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1475698768,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1475698768,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1475698768,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1475698768,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "spali",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=15.9,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=19.6,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=14.1,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=9.85,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=6,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1716553249,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1716553249,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1716553249,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1716553249,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1716553249,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "robins",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=44.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=70.25,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=42,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=20.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=10.3,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1110661133,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1110661133,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1110661133,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1110661133,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1110661133,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "egco",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=126.5,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=152,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=91.5,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=108.5,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=79,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=526465000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=526465000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=526465000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=526465000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=526465000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "glow",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=67.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=79.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=55.75,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=41.25,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=31,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1462865035,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1462865035,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1462865035,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1462865035,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1462865035,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ratch",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=48,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=60.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=44,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=40.25,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=34.5,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=1450000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=1450000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=1450000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=1450000000,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=1450000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ktc",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=28.75,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=41.5,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=14.8,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=12.2,Date=new DateTime(2011,1,1)},
                            new PriceDE {Close=12.5,Date=new DateTime(2010,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=257833407,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=257833407,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=257833407,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=257833407,Date=new DateTime(2010,1,31)},
                            new ShareDE{Amount=257833407,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mfec",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=6.1,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=6.3,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=4.78,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=4.88,Date=new DateTime(2011,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=441453555,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=440400000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=439350000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=438300000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aeonts",
                        Prices = new PriceDE[] 
                        { 
                            new PriceDE {Close=87.25,Date=new DateTime(2014,1,1)},
                            new PriceDE {Close=92,Date=new DateTime(2013,1,1)},
                            new PriceDE {Close=30,Date=new DateTime(2012,1,1)},
                            new PriceDE {Close=32.75,Date=new DateTime(2011,1,1)}
                        },
                        Shares = new ShareDE[] 
                        {
                            new ShareDE{Amount=250000000,Date=new DateTime(2013,1,31)},
                            new ShareDE{Amount=250000000,Date=new DateTime(2012,1,31)},
                            new ShareDE{Amount=250000000,Date=new DateTime(2011,1,31)},
                            new ShareDE{Amount=250000000,Date=new DateTime(2010,1,31)}
                        }
                    }
                };
            }
        }
    }
}