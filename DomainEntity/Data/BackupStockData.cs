using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity.Data
{
    public class BackupStockData
    {
        public static IEnumerable<BackupStockDE> DataV2
        {
            get
            {
                return new List<BackupStockDE>()
                {
                    new BackupStockDE()
                    {
                        Quote = "ptt",
                        Prices = new Price[] 
                        { 
                            new Price {Close=404,Date=new DateTime(2017,1,1)},
                            new Price {Close=236,Date=new DateTime(2016,1,1)},
                            new Price {Close=346,Date=new DateTime(2015,1,1)},
                            new Price {Close=276,Date=new DateTime(2014,1,1)},
                            new Price {Close=341,Date=new DateTime(2013,1,1)},
                            new Price {Close=334,Date=new DateTime(2012,1,1)},
                            new Price {Close=335,Date=new DateTime(2011,1,1)},
                            new Price {Close=223,Date=new DateTime(2010,1,1)},
                            new Price {Close=160,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=94609.08,Year=2016},
                            new Statistic{NetProfit=19936.42,Year=2015},
                            new Statistic{NetProfit=55794.93,Year=2014},
                            new Statistic{NetProfit=94652,Year=2013},
                            new Statistic{NetProfit=104666,Year=2012},
                            new Statistic{NetProfit=105296.41,Year=2011},
                            new Statistic{NetProfit=83087,Year=2010},
                            new Statistic{NetProfit=59547.59,Year=2009},
                            new Statistic{NetProfit=51704.8,Year=2008},
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2856299625,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2856299625,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2856299625,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2856299625,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2856299625,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2856299625,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2849042025,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2833785000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=2824057000,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "work",
                        Prices = new Price[] 
                        { 
                            new Price{Close=51.75,Date=new DateTime(2017,1,1)},
                            new Price{Close=38.5,Date=new DateTime(2016,1,1)},
                            new Price{Close=38.75,Date=new DateTime(2015,1,1)},
                            new Price{Close=22.2,Date=new DateTime(2014,1,1)},
                            new Price{Close=48.25,Date=new DateTime(2013,1,1)},
                            new Price{Close=13.9,Date=new DateTime(2012,1,1)},
                            new Price{Close=12.1,Date=new DateTime(2011,1,1)},
                            new Price{Close=6.8,Date=new DateTime(2010,1,1)},
                            new Price{Close=4.7,Date=new DateTime(2009,1,1)}
                        },
                            Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=198.63,Year=2016},
                            new Statistic{NetProfit=163.66,Year=2015},
                            new Statistic{NetProfit=20.82,Year=2014},
                            new Statistic{NetProfit=256.78,Year=2013},
                            new Statistic{NetProfit=404,Year=2012},
                            new Statistic{NetProfit=327.352,Year=2011},
                            new Statistic{NetProfit=186.87,Year=2010},
                            new Statistic{NetProfit=73.13,Year=2009},
                            new Statistic{NetProfit=162.06,Year=2008},
                        },
                            Shares = new Share[] 
                        {
                            new Share{Amount=420110717,Date=new DateTime(2016,1,31)},
                            new Share{Amount=420110717,Date=new DateTime(2015,1,31)},
                            new Share{Amount=420110717,Date=new DateTime(2014,1,31)},
                            new Share{Amount=257107972,Date=new DateTime(2013,1,31)},
                            new Share{Amount=257107972,Date=new DateTime(2012,1,31)},
                            new Share{Amount=250250000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=200000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=200000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=200000000,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "earth",
                        Prices = new Price[] 
                        { 
                            new Price{Close=4.54,Date=new DateTime(2017,1,1)},
                            new Price{Close=4.7,Date=new DateTime(2016,1,1)},
                            new Price{Close=4.56,Date=new DateTime(2015,1,1)},
                            new Price{Close=6.1,Date=new DateTime(2014,1,1)},
                            new Price{Close=8.25,Date=new DateTime(2013,1,1)},
                            new Price{Close=4.2,Date=new DateTime(2012,1,1)},
                            new Price{Close=2.04,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=871.90,Year=2016},
                            new Statistic{NetProfit=1026.88,Year=2015},
                            new Statistic{NetProfit=1042.03,Year=2014},
                            new Statistic{NetProfit=1110.6,Year=2013},
                            new Statistic{NetProfit=1280.44,Year=2012},
                            new Statistic{NetProfit=395.31,Year=2011},
                            new Statistic{NetProfit=70.78,Year=2010}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3536601827,Date=new DateTime(2016,1,31)},
                            new Share{Amount=3536601827,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3536601827,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2949088091,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2605495683,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2554299239,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2554299239,Date=new DateTime(2010,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.23,Median=0.23,Year=2018},
                            new Consensus{Average=0.25,Median=0.25,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "banpu",
                        Prices = new Price[] 
                        { 
                            new Price{Close=19.4,Date=new DateTime(2017,1,1)},
                            new Price{Close=12.73,Date=new DateTime(2016,1,1)},
                            new Price{Close=18.41,Date=new DateTime(2015,1,1)},
                            new Price{Close=20.08,Date=new DateTime(2014,1,1)},
                            new Price{Close=29.55,Date=new DateTime(2013,1,1)},
                            new Price{Close=700.7,Date=new DateTime(2012,1,1)},
                            new Price{Close=723.28,Date=new DateTime(2011,1,1)},
                            new Price{Close=509.2,Date=new DateTime(2010,1,1)},
                            new Price{Close=207.14,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1677.12,Year=2016},
                            new Statistic{NetProfit=-1534.25,Year=2015},
                            new Statistic{NetProfit=2679.63,Year=2014},
                            new Statistic{NetProfit=3151,Year=2013},
                            new Statistic{NetProfit=9293.2,Year=2012},
                            new Statistic{NetProfit=20059.83,Year=2011},
                            new Statistic{NetProfit=24727.72,Year=2010},
                            new Statistic{NetProfit=14229.13,Year=2009},
                            new Statistic{NetProfit=9227.67,Year=2008},
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=5060634213,Date=new DateTime(2016,1,31)},
                            new Share{Amount=5060634213,Date=new DateTime(2015,1,31)},
                            new Share{Amount=5060634213,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2581878550,Date=new DateTime(2013,1,31)},
                            new Share{Amount=271747855,Date=new DateTime(2012,1,31)},
                            new Share{Amount=271747855,Date=new DateTime(2011,1,31)},
                            new Share{Amount=271747855,Date=new DateTime(2010,1,31)},
                            new Share{Amount=271747855,Date=new DateTime(2009,1,31)},
                            new Share{Amount=271747855,Date=new DateTime(2008,1,31)},
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "gunkul",
                        Prices = new Price[] 
                        { 
                            new Price {Close=4.84,Date=new DateTime(2017,1,1)},
                            new Price {Close=4.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=4.54,Date=new DateTime(2015,1,1)},
                            new Price {Close=1.35,Date=new DateTime(2014,1,1)},
                            new Price {Close=1.84,Date=new DateTime(2013,1,1)},
                            new Price {Close=10.91,Date=new DateTime(2012,1,1)},
                            new Price {Close=4.61,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=537.72,Year=2016},
                            new Statistic{NetProfit=685.14,Year=2015},
                            new Statistic{NetProfit=545.27,Year=2014},
                            new Statistic{NetProfit=882.9,Year=2013},
                            new Statistic{NetProfit=779.56,Year=2012},
                            new Statistic{NetProfit=89.52,Year=2011},
                            new Statistic{NetProfit=123.18,Year=2010}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=6358775851,Date=new DateTime(2016,1,31)},
                            new Share{Amount=6358775851,Date=new DateTime(2015,1,31)},
                            new Share{Amount=6358775851,Date=new DateTime(2014,1,31)},
                            new Share{Amount=6358775851,Date=new DateTime(2013,1,31)},
                            new Share{Amount=440000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=400000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=400000000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ivl",
                        Prices = new Price[] 
                        { 
                            new Price {Close=35,Date=new DateTime(2017,1,1)},
                            new Price {Close=21,Date=new DateTime(2016,1,1)},
                            new Price {Close=21.8,Date=new DateTime(2015,1,1)},
                            new Price {Close=20.7,Date=new DateTime(2014,1,1)},
                            new Price {Close=26.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=32,Date=new DateTime(2012,1,1)},
                            new Price {Close=39,Date=new DateTime(2011,1,1)},
                            new Price {Close=9.43,Date=new DateTime(2010,1,1)},
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=16197.10,Year=2016},
                            new Statistic{NetProfit=6609.26,Year=2015},
                            new Statistic{NetProfit=1485.38,Year=2014},
                            new Statistic{NetProfit=1325.87,Year=2013},
                            new Statistic{NetProfit=4611,Year=2012},
                            new Statistic{NetProfit=15567.97,Year=2011},
                            new Statistic{NetProfit=10560.44,Year=2010},
                            new Statistic{NetProfit=4824,Year=2009},
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4814327781,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4814327781,Date=new DateTime(2015,1,31)},
                            new Share{Amount=4814327781,Date=new DateTime(2014,1,31)},
                            new Share{Amount=4814257245,Date=new DateTime(2013,1,31)},
                            new Share{Amount=4814257245,Date=new DateTime(2012,1,31)},
                            new Share{Amount=4814257245,Date=new DateTime(2011,1,31)},
                            new Share{Amount=4814257245,Date=new DateTime(2010,1,31)},
                            new Share{Amount=4814257245,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ptl",
                        Prices = new Price[] 
                        { 
                            new Price {Close=18.4,Date=new DateTime(2017,1,1)},
                            new Price {Close=6.42,Date=new DateTime(2016,1,1)},
                            new Price {Close=10.55,Date=new DateTime(2015,1,1)},
                            new Price {Close=8.8,Date=new DateTime(2014,1,1)},
                            new Price {Close=12.1,Date=new DateTime(2013,1,1)},
                            new Price {Close=15.9,Date=new DateTime(2012,1,1)},
                            new Price {Close=22.8,Date=new DateTime(2011,1,1)},
                            new Price {Close=6.85,Date=new DateTime(2010,1,1)},
                            new Price {Close=3.98,Date=new DateTime(2009,1,1)},
                            new Price {Close=3.72,Date=new DateTime(2008,1,1)},
                            new Price {Close=5.96,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1059.29,Year=2016},
                            new Statistic{NetProfit=-123.23,Year=2015},
                            new Statistic{NetProfit=388.04,Year=2014},
                            new Statistic{NetProfit=-479.72,Year=2013},
                            new Statistic{NetProfit=373.97,Year=2012},
                            new Statistic{NetProfit=1361.68,Year=2011},
                            new Statistic{NetProfit=3882.88,Year=2010},
                            new Statistic{NetProfit=1039.39,Year=2009},
                            new Statistic{NetProfit=1041.97,Year=2008},
                            new Statistic{NetProfit=813.55,Year=2007},
                            new Statistic{NetProfit=341.84,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=900000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=800000000,Date=new DateTime(2006,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=1.1,Median=1.1,Year=2018},
                            new Consensus{Average=1,Median=1,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aj",
                        Prices = new Price[] 
                        { 
                            new Price {Close=13.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=5.8,Date=new DateTime(2016,1,1)},
                            new Price {Close=9.1,Date=new DateTime(2015,1,1)},
                            new Price {Close=8.85,Date=new DateTime(2014,1,1)},
                            new Price {Close=16.6,Date=new DateTime(2013,1,1)},
                            new Price {Close=16.6,Date=new DateTime(2012,1,1)},
                            new Price {Close=25.68,Date=new DateTime(2011,1,1)},
                            new Price {Close=3.41,Date=new DateTime(2010,1,1)},
                            new Price {Close=2.53,Date=new DateTime(2009,1,1)},
                            new Price {Close=1.87,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=121.25	,Year=2016},
                            new Statistic{NetProfit=3.79,Year=2015},
                            new Statistic{NetProfit=-247.86,Year=2014},
                            new Statistic{NetProfit=-97.98,Year=2013},
                            new Statistic{NetProfit=190,Year=2012},
                            new Statistic{NetProfit=878.6,Year=2011},
                            new Statistic{NetProfit=984.92,Year=2010},
                            new Statistic{NetProfit=288.05,Year=2009},
                            new Statistic{NetProfit=160.31,Year=2008},
                            new Statistic{NetProfit=129.64,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=399439227,Date=new DateTime(2016,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2015,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2014,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2013,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2012,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2011,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2010,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2009,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2008,1,31)},
                            new Share{Amount=399439227,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.27,Median=0.27,Year=2018},
                            new Consensus{Average=0.25,Median=0.25,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "vnt",
                        Prices = new Price[] 
                        { 
                            new Price {Close=17.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=9.7,Date=new DateTime(2016,1,1)},
                            new Price {Close=10.2,Date=new DateTime(2015,1,1)},
                            new Price {Close=10.7,Date=new DateTime(2014,1,1)},
                            new Price {Close=20.4,Date=new DateTime(2013,1,1)},
                            new Price {Close=17.61,Date=new DateTime(2012,1,1)},
                            new Price {Close=11.55,Date=new DateTime(2011,1,1)},
                            new Price {Close=6.05,Date=new DateTime(2010,1,1)},
                            new Price {Close=3.16,Date=new DateTime(2009,1,1)},
                            new Price {Close=5.77,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1123.70,Year=2016},
                            new Statistic{NetProfit=566.02,Year=2015},
                            new Statistic{NetProfit=-963.72,Year=2014},
                            new Statistic{NetProfit=198.17,Year=2013},
                            new Statistic{NetProfit=1682.89,Year=2012},
                            new Statistic{NetProfit=1989.25,Year=2011},
                            new Statistic{NetProfit=1508.08,Year=2010},
                            new Statistic{NetProfit=985.25,Year=2009},
                            new Statistic{NetProfit=1034.81,Year=2008},
                            new Statistic{NetProfit=654.48,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1185193444,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1185193444,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.9955,Median=0.9955,Year=2018},
                            new Consensus{Average=1.045,Median=1.045,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bcp",
                        Prices = new Price[] 
                        { 
                            new Price {Close=35.25,Date=new DateTime(2017,1,1)},
                            new Price {Close=29.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=34.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=26.75,Date=new DateTime(2014,1,1)},
                            new Price {Close=36,Date=new DateTime(2013,1,1)},
                            new Price {Close=19.64,Date=new DateTime(2012,1,1)},
                            new Price {Close=16.84,Date=new DateTime(2011,1,1)},
                            new Price {Close=12.76,Date=new DateTime(2010,1,1)},
                            new Price {Close=5.81,Date=new DateTime(2009,1,1)},
                            new Price {Close=10.19,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=4773.38,Year=2016},
                            new Statistic{NetProfit=4150.76,Year=2015},
                            new Statistic{NetProfit=711.59,Year=2014},
                            new Statistic{NetProfit=4652.92,Year=2013},
                            new Statistic{NetProfit=4272.56,Year=2012},
                            new Statistic{NetProfit=5610.16,Year=2011},
                            new Statistic{NetProfit=2812.81,Year=2010},
                            new Statistic{NetProfit=7524.26,Year=2009},
                            new Statistic{NetProfit=-750.09,Year=2008},
                            new Statistic{NetProfit=1763.76,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1376923157,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1376923157,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1376923157,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1376923157,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1376923157,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1376923157,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1372170011,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1372170011,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1372170011,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1372170011,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "pttep",
                        Prices = new Price[] 
                        { 
                            new Price {Close=98,Date=new DateTime(2017,1,1)},
                            new Price {Close=57,Date=new DateTime(2016,1,1)},
                            new Price {Close=109,Date=new DateTime(2015,1,1)},
                            new Price {Close=153,Date=new DateTime(2014,1,1)},
                            new Price {Close=166,Date=new DateTime(2013,1,1)},
                            new Price {Close=174.51,Date=new DateTime(2012,1,1)},
                            new Price {Close=160.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=132,Date=new DateTime(2010,1,1)},
                            new Price {Close=99,Date=new DateTime(2009,1,1)},
                            new Price {Close=147,Date=new DateTime(2008,1,1)},
                            new Price {Close=93,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=12859.72,Year=2016},
                            new Statistic{NetProfit=-31590.49,Year=2015},
                            new Statistic{NetProfit=21490.45,Year=2014},
                            new Statistic{NetProfit=56154.77,Year=2013},
                            new Statistic{NetProfit=57315.96,Year=2012},
                            new Statistic{NetProfit=44748,Year=2011},
                            new Statistic{NetProfit=41739,Year=2010},
                            new Statistic{NetProfit=22153.6,Year=2009},
                            new Statistic{NetProfit=41674.84,Year=2008},
                            new Statistic{NetProfit=28455.39,Year=2007},
                            new Statistic{NetProfit=28047.27,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3969985400,Date=new DateTime(2016,1,31)},
                            new Share{Amount=3969985400,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3969985400,Date=new DateTime(2014,1,31)},
                            new Share{Amount=3969985400,Date=new DateTime(2013,1,31)},
                            new Share{Amount=3969985400,Date=new DateTime(2012,1,31)},
                            new Share{Amount=3319985400,Date=new DateTime(2011,1,31)},
                            new Share{Amount=3318433600,Date=new DateTime(2010,1,31)},
                            new Share{Amount=3312560000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=3307080000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=3297420000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=3286000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "pttgc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=67.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=53.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=56.50,Date=new DateTime(2015,1,1)},
                            new Price {Close=71.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=80,Date=new DateTime(2013,1,1)},
                            new Price {Close=65.45,Date=new DateTime(2012,1,1)},
                            new Price {Close=37,Date=new DateTime(2011,1,1)},
                            new Price {Close=24.7,Date=new DateTime(2010,1,1)},
                            new Price {Close=9.8,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=25601.63,Year=2016},
                            new Statistic{NetProfit=20502.50,Year=2015},
                            new Statistic{NetProfit=15036.03,Year=2014},
                            new Statistic{NetProfit=33277.41,Year=2013},
                            new Statistic{NetProfit=34001.27,Year=2012},
                            new Statistic{NetProfit=30033,Year=2011},
                            new Statistic{NetProfit=6342.88,Year=2010},
                            new Statistic{NetProfit=9161.56,Year=2009},
                            new Statistic{NetProfit=-8464.66,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4508849117,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4508849117,Date=new DateTime(2015,1,31)},
                            new Share{Amount=4508849117,Date=new DateTime(2014,1,31)},
                            new Share{Amount=4508849117,Date=new DateTime(2013,1,31)},
                            new Share{Amount=4507624281,Date=new DateTime(2012,1,31)},
                            new Share{Amount=4506643000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2979106161,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2967072148,Date=new DateTime(2009,1,31)},
                            new Share{Amount=2967072148,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "scc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=510,Date=new DateTime(2017,1,1)},
                            new Price {Close=432,Date=new DateTime(2016,1,1)},
                            new Price {Close=496,Date=new DateTime(2015,1,1)},
                            new Price {Close=406,Date=new DateTime(2014,1,1)},
                            new Price {Close=444,Date=new DateTime(2013,1,1)},
                            new Price {Close=339.93,Date=new DateTime(2012,1,1)},
                            new Price {Close=312,Date=new DateTime(2011,1,1)},
                            new Price {Close=217,Date=new DateTime(2010,1,1)},
                            new Price {Close=102,Date=new DateTime(2009,1,1)},
                            new Price {Close=204,Date=new DateTime(2008,1,1)},
                            new Price {Close=232,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=56084.19,Year=2016},
                            new Statistic{NetProfit=45399.71,Year=2015},
                            new Statistic{NetProfit=33615.33,Year=2014},
                            new Statistic{NetProfit=36522.25,Year=2013},
                            new Statistic{NetProfit=23579.99,Year=2012},
                            new Statistic{NetProfit=27280.66,Year=2011},
                            new Statistic{NetProfit=37382,Year=2010},
                            new Statistic{NetProfit=24345.5,Year=2009},
                            new Statistic{NetProfit=16770.61,Year=2008},
                            new Statistic{NetProfit=30351.9,Year=2007},
                            new Statistic{NetProfit=29450.69,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1200000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "kce",
                        Prices = new Price[] 
                        { 
                            new Price {Close=109,Date=new DateTime(2017,1,1)},
                            new Price {Close=76.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=47.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=22.8,Date=new DateTime(2014,1,1)},
                            new Price {Close=10.4,Date=new DateTime(2013,1,1)},
                            new Price {Close=4.84,Date=new DateTime(2012,1,1)},
                            new Price {Close=7.4,Date=new DateTime(2011,1,1)},
                            new Price {Close=5.25,Date=new DateTime(2010,1,1)},
                            new Price {Close=0.91,Date=new DateTime(2009,1,1)},
                            new Price {Close=3.36,Date=new DateTime(2008,1,1)},
                            new Price {Close=2.79,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=3038.75,Year=2016},
                            new Statistic{NetProfit=2240.11,Year=2015},
                            new Statistic{NetProfit=2109.77,Year=2014},
                            new Statistic{NetProfit=1173.5,Year=2013},
                            new Statistic{NetProfit=712.33,Year=2012},
                            new Statistic{NetProfit=132.02,Year=2011},
                            new Statistic{NetProfit=535,Year=2010},
                            new Statistic{NetProfit=171.55,Year=2009},
                            new Statistic{NetProfit=-399.17,Year=2008},
                            new Statistic{NetProfit=257.43,Year=2007},
                            new Statistic{NetProfit=-116.35,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=586396798,Date=new DateTime(2016,1,31)},
                            new Share{Amount=574760000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=565630000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=474995769,Date=new DateTime(2013,1,31)},
                            new Share{Amount=472600769,Date=new DateTime(2012,1,31)},
                            new Share{Amount=464053000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=471067269,Date=new DateTime(2010,1,31)},
                            new Share{Amount=462500000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=462500000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=462500000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=314930000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hana",
                        Prices = new Price[] 
                        { 
                            new Price {Close=42.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=30.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=40.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=24.8,Date=new DateTime(2014,1,1)},
                            new Price {Close=24.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=17.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=25.25,Date=new DateTime(2011,1,1)},
                            new Price {Close=21,Date=new DateTime(2010,1,1)},
                            new Price {Close=11,Date=new DateTime(2009,1,1)},
                            new Price {Close=19,Date=new DateTime(2008,1,1)},
                            new Price {Close=24.4,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2105.42,Year=2016},
                            new Statistic{NetProfit=2066.37,Year=2015},
                            new Statistic{NetProfit=3405.50,Year=2014},
                            new Statistic{NetProfit=2337.2,Year=2013},
                            new Statistic{NetProfit=1661,Year=2012},
                            new Statistic{NetProfit=1618.07,Year=2011},
                            new Statistic{NetProfit=2749,Year=2010},
                            new Statistic{NetProfit=2042.96,Year=2009},
                            new Statistic{NetProfit=1909.55,Year=2008},
                            new Statistic{NetProfit=2449.16,Year=2007},
                            new Statistic{NetProfit=2216.2,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=804878860,Date=new DateTime(2016,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2015,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2014,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2013,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2012,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2011,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2010,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2009,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2008,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2007,1,31)},
                            new Share{Amount=804878860,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "delta",
                        Prices = new Price[] 
                        { 
                            new Price {Close=85.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=79.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=74.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=53,Date=new DateTime(2014,1,1)},
                            new Price {Close=35.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=20.33,Date=new DateTime(2012,1,1)},
                            new Price {Close=28.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=15.17,Date=new DateTime(2010,1,1)},
                            new Price {Close=7.41,Date=new DateTime(2009,1,1)},
                            new Price {Close=15.14,Date=new DateTime(2008,1,1)},
                            new Price {Close=11.69,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=5516.29,Year=2016},
                            new Statistic{NetProfit=6713.82,Year=2015},
                            new Statistic{NetProfit=5961.65,Year=2014},
                            new Statistic{NetProfit=5415.69,Year=2013},
                            new Statistic{NetProfit=4347.38,Year=2012},
                            new Statistic{NetProfit=2864.33,Year=2011},
                            new Statistic{NetProfit=4152.57,Year=2010},
                            new Statistic{NetProfit=2189.38,Year=2009},
                            new Statistic{NetProfit=2897.48,Year=2008},
                            new Statistic{NetProfit=3155.42,Year=2007},
                            new Statistic{NetProfit=1961.71,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1247381614,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2007,1,31)},
                            new Share{Amount=1247381614,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "advanc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=159,Date=new DateTime(2017,1,1)},
                            new Price {Close=169,Date=new DateTime(2016,1,1)},
                            new Price {Close=245,Date=new DateTime(2015,1,1)},
                            new Price {Close=209,Date=new DateTime(2014,1,1)},
                            new Price {Close=210,Date=new DateTime(2013,1,1)},
                            new Price {Close=147.85,Date=new DateTime(2012,1,1)},
                            new Price {Close=80,Date=new DateTime(2011,1,1)},
                            new Price {Close=83,Date=new DateTime(2010,1,1)},
                            new Price {Close=75,Date=new DateTime(2009,1,1)},
                            new Price {Close=93.5,Date=new DateTime(2008,1,1)},
                            new Price {Close=73,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=30666.54,Year=2016},
                            new Statistic{NetProfit=39152.41,Year=2015},
                            new Statistic{NetProfit=36033.17,Year=2014},
                            new Statistic{NetProfit=36274.13,Year=2013},
                            new Statistic{NetProfit=34883.23,Year=2012},
                            new Statistic{NetProfit=22217.71,Year=2011},
                            new Statistic{NetProfit=20547,Year=2010},
                            new Statistic{NetProfit=17055.37,Year=2009},
                            new Statistic{NetProfit=16409.04,Year=2008},
                            new Statistic{NetProfit=16290.47,Year=2007},
                            new Statistic{NetProfit=16256.02,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2973095330,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2973095330,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2973095330,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2973095330,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2973095330,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2973095330,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2968527952,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2965440000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=2961740000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=2958120000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=2953550000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "dtac",
                        Prices = new Price[] 
                        { 
                            new Price {Close=39.25,Date=new DateTime(2017,1,1)},
                            new Price {Close=33.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=94,Date=new DateTime(2015,1,1)},
                            new Price {Close=95.75,Date=new DateTime(2014,1,1)},
                            new Price {Close=86.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=66,Date=new DateTime(2012,1,1)},
                            new Price {Close=40.25,Date=new DateTime(2011,1,1)},
                            new Price {Close=32.25,Date=new DateTime(2010,1,1)},
                            new Price {Close=29.5,Date=new DateTime(2009,1,1)},
                            new Price {Close=39.25,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2085.83,Year=2016},
                            new Statistic{NetProfit=5893.11,Year=2015},
                            new Statistic{NetProfit=10728.75,Year=2014},
                            new Statistic{NetProfit=10569.38,Year=2013},
                            new Statistic{NetProfit=11278.08,Year=2012},
                            new Statistic{NetProfit=11812.85,Year=2011},
                            new Statistic{NetProfit=10892,Year=2010},
                            new Statistic{NetProfit=6627.77,Year=2009},
                            new Statistic{NetProfit=9329.1,Year=2008},
                            new Statistic{NetProfit=5841.42,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2367811000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=2367811000,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "jas",
                        Prices = new Price[] 
                        { 
                            new Price {Close=8.70,Date=new DateTime(2017,1,1)},
                            new Price {Close=3.12,Date=new DateTime(2016,1,1)},
                            new Price {Close=8.30,Date=new DateTime(2015,1,1)},
                            new Price {Close=7.05,Date=new DateTime(2014,1,1)},
                            new Price {Close=6,Date=new DateTime(2013,1,1)},
                            new Price {Close=2.02,Date=new DateTime(2012,1,1)},
                            new Price {Close=1.8,Date=new DateTime(2011,1,1)},
                            new Price {Close=0.45,Date=new DateTime(2010,1,1)},
                            new Price {Close=0.36,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=3001.61,Year=2016},
                            new Statistic{NetProfit=15710.41,Year=2015},
                            new Statistic{NetProfit=3270.86,Year=2014},
                            new Statistic{NetProfit=3002.51,Year=2013},
                            new Statistic{NetProfit=2136.5,Year=2012},
                            new Statistic{NetProfit=1072.498,Year=2011},
                            new Statistic{NetProfit=663.29,Year=2010},
                            new Statistic{NetProfit=203.52,Year=2009},
                            new Statistic{NetProfit=-1244.92,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=6377626296,Date=new DateTime(2016,1,31)},
                            new Share{Amount=6377626296,Date=new DateTime(2015,1,31)},
                            new Share{Amount=6377626296,Date=new DateTime(2014,1,31)},
                            new Share{Amount=7137394378,Date=new DateTime(2013,1,31)},
                            new Share{Amount=7137394378,Date=new DateTime(2012,1,31)},
                            new Share{Amount=7244000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=7244000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=7244000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=7244000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bland",
                        Prices = new Price[] 
                        { 
                            new Price {Close=1.90,Date=new DateTime(2017,1,1)},
                            new Price {Close=1.43,Date=new DateTime(2016,1,1)},
                            new Price {Close=1.76,Date=new DateTime(2015,1,1)},
                            new Price {Close=1.43,Date=new DateTime(2014,1,1)},
                            new Price {Close=1.7,Date=new DateTime(2013,1,1)},
                            new Price {Close=0.71,Date=new DateTime(2012,1,1)},
                            new Price {Close=0.62,Date=new DateTime(2011,1,1)},
                            new Price {Close=0.52,Date=new DateTime(2010,1,1)},
                            new Price {Close=0.23,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=3443.02,Year=2016},
                            new Statistic{NetProfit=1203.42,Year=2015},
                            new Statistic{NetProfit=2096.22,Year=2014},
                            new Statistic{NetProfit=2337.87,Year=2013},
                            new Statistic{NetProfit=621.2,Year=2012},
                            new Statistic{NetProfit=789.55,Year=2011},
                            new Statistic{NetProfit=528.65,Year=2010},
                            new Statistic{NetProfit=1746.28,Year=2009},
                            new Statistic{NetProfit=6022.72,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=18596218294,Date=new DateTime(2016,1,31)},
                            new Share{Amount=18596218294,Date=new DateTime(2015,1,31)},
                            new Share{Amount=18596218294,Date=new DateTime(2014,1,31)},
                            new Share{Amount=18012968488,Date=new DateTime(2013,1,31)},
                            new Share{Amount=17795295397,Date=new DateTime(2012,1,31)},
                            new Share{Amount=17795295397,Date=new DateTime(2011,1,31)},
                            new Share{Amount=17795295397,Date=new DateTime(2010,1,31)},
                            new Share{Amount=17795295397,Date=new DateTime(2009,1,31)},
                            new Share{Amount=17795295397,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "sc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=3.80,Date=new DateTime(2017,1,1)},
                            new Price {Close=2.90,Date=new DateTime(2016,1,1)},
                            new Price {Close=3.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=2.98,Date=new DateTime(2014,1,1)},
                            new Price {Close=30.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=14.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=8.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=5.25,Date=new DateTime(2010,1,1)},
                            new Price {Close=3.05,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1968.21,Year=2016},
                            new Statistic{NetProfit=1895.28,Year=2015},
                            new Statistic{NetProfit=1558.13,Year=2014},
                            new Statistic{NetProfit=1081.62,Year=2013},
                            new Statistic{NetProfit=1108,Year=2012},
                            new Statistic{NetProfit=1079.31,Year=2011},
                            new Statistic{NetProfit=1152.32,Year=2010},
                            new Statistic{NetProfit=764.01,Year=2009},
                            new Statistic{NetProfit=650.31,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4179332012,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4179332012,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3714970000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=3712620000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=658640200,Date=new DateTime(2012,1,31)},
                            new Share{Amount=658640200,Date=new DateTime(2011,1,31)},
                            new Share{Amount=658640200,Date=new DateTime(2010,1,31)},
                            new Share{Amount=658640200,Date=new DateTime(2009,1,31)},
                            new Share{Amount=658640200,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "lh",
                        Prices = new Price[] 
                        { 
                            new Price {Close=9.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=8.8,Date=new DateTime(2016,1,1)},
                            new Price {Close=9.2,Date=new DateTime(2015,1,1)},
                            new Price {Close=8.6,Date=new DateTime(2014,1,1)},
                            new Price {Close=11.3,Date=new DateTime(2013,1,1)},
                            new Price {Close=6.4,Date=new DateTime(2012,1,1)},
                            new Price {Close=5.55,Date=new DateTime(2011,1,1)},
                            new Price {Close=5.45,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=8617.97,Year=2016},
                            new Statistic{NetProfit=7920.23,Year=2015},
                            new Statistic{NetProfit=8423.07,Year=2014},
                            new Statistic{NetProfit=6478.4,Year=2013},
                            new Statistic{NetProfit=5635.73,Year=2012},
                            new Statistic{NetProfit=5608.56,Year=2011},
                            new Statistic{NetProfit=3971.16,Year=2010},
                            new Statistic{NetProfit=3908.47,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=11917701721,Date=new DateTime(2016,1,31)},
                            new Share{Amount=11730030000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=10985570000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=10025921523,Date=new DateTime(2013,1,31)},
                            new Share{Amount=10025921523,Date=new DateTime(2012,1,31)},
                            new Share{Amount=10025921523,Date=new DateTime(2011,1,31)},
                            new Share{Amount=10025921523,Date=new DateTime(2010,1,31)},
                            new Share{Amount=10025921523,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "siri",
                        Prices = new Price[] 
                        { 
                            new Price {Close=1.87,Date=new DateTime(2017,1,1)},
                            new Price {Close=1.51,Date=new DateTime(2016,1,1)},
                            new Price {Close=1.81,Date=new DateTime(2015,1,1)},
                            new Price {Close=1.81,Date=new DateTime(2014,1,1)},
                            new Price {Close=4.14,Date=new DateTime(2013,1,1)},
                            new Price {Close=1.85,Date=new DateTime(2012,1,1)},
                            new Price {Close=5.4,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.36,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.78,Date=new DateTime(2009,1,1)},
                            new Price {Close=3.48,Date=new DateTime(2008,1,1)},
                            new Price {Close=2.96,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=3380.43,Year=2016},
                            new Statistic{NetProfit=3505.92,Year=2015},
                            new Statistic{NetProfit=3393.14,Year=2014},
                            new Statistic{NetProfit=1929.67,Year=2013},
                            new Statistic{NetProfit=2947,Year=2012},
                            new Statistic{NetProfit=2015.08,Year=2011},
                            new Statistic{NetProfit=1897.73,Year=2010},
                            new Statistic{NetProfit=1607.54,Year=2009},
                            new Statistic{NetProfit=913.61,Year=2008},
                            new Statistic{NetProfit=707.93,Year=2007},
                            new Statistic{NetProfit=404.25,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=14285501270,Date=new DateTime(2016,1,31)},
                            new Share{Amount=14285501270,Date=new DateTime(2015,1,31)},
                            new Share{Amount=14285501270,Date=new DateTime(2014,1,31)},
                            new Share{Amount=9099155119,Date=new DateTime(2013,1,31)},
                            new Share{Amount=8364454765,Date=new DateTime(2012,1,31)},
                            new Share{Amount=7150071000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1505959692,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1486328692,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1486328692,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1486328692,Date=new DateTime(2007,1,31)},
                            new Share{Amount=1486328692,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "prin",
                        Prices = new Price[] 
                        { 
                            new Price {Close=1.54,Date=new DateTime(2017,1,1)},
                            new Price {Close=1.26,Date=new DateTime(2016,1,1)},
                            new Price {Close=2.1,Date=new DateTime(2015,1,1)},
                            new Price {Close=1.34,Date=new DateTime(2014,1,1)},
                            new Price {Close=2.22,Date=new DateTime(2013,1,1)},
                            new Price {Close=1.39,Date=new DateTime(2012,1,1)},
                            new Price {Close=2,Date=new DateTime(2011,1,1)},
                            new Price {Close=1.85,Date=new DateTime(2010,1,1)},
                            new Price {Close=0.71,Date=new DateTime(2009,1,1)},
                            new Price {Close=2.73,Date=new DateTime(2008,1,1)},
                            new Price {Close=2.94,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=215.90,Year=2016},
                            new Statistic{NetProfit=66.40,Year=2015},
                            new Statistic{NetProfit=74.50,Year=2014},
                            new Statistic{NetProfit=191.8,Year=2013},
                            new Statistic{NetProfit=354,Year=2012},
                            new Statistic{NetProfit=203.05,Year=2011},
                            new Statistic{NetProfit=573,Year=2010},
                            new Statistic{NetProfit=483.89,Year=2009},
                            new Statistic{NetProfit=315.56,Year=2008},
                            new Statistic{NetProfit=77.98,Year=2007},
                            new Statistic{NetProfit=447.8,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1220011755,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1220011755,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1220011755,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1219303655,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1219303655,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1216041855,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1105499456,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1005000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1005000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1005000000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=670000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpn",
                        Prices = new Price[] 
                        { 
                            new Price {Close=56.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=44.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=44.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=37.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=86,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=9243.80,Year=2016},
                            new Statistic{NetProfit=7880.31,Year=2015},
                            new Statistic{NetProfit=7306.95,Year=2014},
                            new Statistic{NetProfit=6292.53,Year=2013},
                            new Statistic{NetProfit=6188.7,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4488000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4488000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=4488000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=4357632000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2178816000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "smit",
                        Prices = new Price[] 
                        { 
                            new Price {Close=4.32,Date=new DateTime(2017,1,1)},
                            new Price {Close=4.12,Date=new DateTime(2016,1,1)},
                            new Price {Close=4.54,Date=new DateTime(2015,1,1)},
                            new Price {Close=4.72,Date=new DateTime(2014,1,1)},
                            new Price {Close=5.1,Date=new DateTime(2013,1,1)},
                            new Price {Close=3.44,Date=new DateTime(2012,1,1)},
                            new Price {Close=2.66,Date=new DateTime(2011,1,1)},
                            new Price {Close=1.44,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.36,Date=new DateTime(2009,1,1)},
                            new Price {Close=2.06,Date=new DateTime(2008,1,1)},
                            new Price {Close=1.88,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=196.85,Year=2016},
                            new Statistic{NetProfit=159.22,Year=2015},
                            new Statistic{NetProfit=194.44,Year=2014},
                            new Statistic{NetProfit=264.16,Year=2013},
                            new Statistic{NetProfit=303.21,Year=2012},
                            new Statistic{NetProfit=221.84,Year=2011},
                            new Statistic{NetProfit=200.25,Year=2010},
                            new Statistic{NetProfit=40.13,Year=2009},
                            new Statistic{NetProfit=142.61,Year=2008},
                            new Statistic{NetProfit=166.43,Year=2007},
                            new Statistic{NetProfit=161.14,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=530000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=530000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=530000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=530000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=530000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=520384000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=526252700,Date=new DateTime(2010,1,31)},
                            new Share{Amount=526252700,Date=new DateTime(2009,1,31)},
                            new Share{Amount=526252700,Date=new DateTime(2008,1,31)},
                            new Share{Amount=526252700,Date=new DateTime(2007,1,31)},
                            new Share{Amount=526252700,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mcs",
                        Prices = new Price[] 
                        { 
                            new Price {Close=17.1,Date=new DateTime(2017,1,1)},
                            new Price {Close=11,Date=new DateTime(2016,1,1)},
                            new Price {Close=6.1,Date=new DateTime(2015,1,1)},
                            new Price {Close=4.14,Date=new DateTime(2014,1,1)},
                            new Price {Close=6.95,Date=new DateTime(2013,1,1)},
                            new Price {Close=9.16,Date=new DateTime(2012,1,1)},
                            new Price {Close=9.68,Date=new DateTime(2011,1,1)},
                            new Price {Close=3.7,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.51,Date=new DateTime(2009,1,1)},
                            new Price {Close=2.49,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1229.26,Year=2016},
                            new Statistic{NetProfit=618.22,Year=2015},
                            new Statistic{NetProfit=82.02,Year=2014},
                            new Statistic{NetProfit=393.11,Year=2013},
                            new Statistic{NetProfit=164.95,Year=2012},
                            new Statistic{NetProfit=476.31,Year=2011},
                            new Statistic{NetProfit=810.97,Year=2010},
                            new Statistic{NetProfit=576.26,Year=2009},
                            new Statistic{NetProfit=353.52,Year=2008},
                            new Statistic{NetProfit=328.94,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=473000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=500000000,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "snc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=15.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=13.7,Date=new DateTime(2016,1,1)},
                            new Price {Close=15.2,Date=new DateTime(2015,1,1)},
                            new Price {Close=15,Date=new DateTime(2014,1,1)},
                            new Price {Close=24.8,Date=new DateTime(2013,1,1)},
                            new Price {Close=23.45,Date=new DateTime(2012,1,1)},
                            new Price {Close=19.11,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.94,Date=new DateTime(2010,1,1)},
                            new Price {Close=3.04,Date=new DateTime(2009,1,1)},
                            new Price {Close=7.88,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=401.65,Year=2016},
                            new Statistic{NetProfit=409.86,Year=2015},
                            new Statistic{NetProfit=377.36,Year=2014},
                            new Statistic{NetProfit=423.21,Year=2013},
                            new Statistic{NetProfit=493.81,Year=2012},
                            new Statistic{NetProfit=519.74,Year=2011},
                            new Statistic{NetProfit=381.32,Year=2010},
                            new Statistic{NetProfit=138.72,Year=2009},
                            new Statistic{NetProfit=98.71,Year=2008},
                            new Statistic{NetProfit=206.13,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=287777339,Date=new DateTime(2016,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2015,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2014,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2013,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2012,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2011,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2010,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2009,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2008,1,31)},
                            new Share{Amount=287777339,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bjchi",
                        Prices = new Price[] 
                        { 
                            new Price {Close=5.15,Date=new DateTime(2017,1,1)},
                            new Price {Close=5.8,Date=new DateTime(2016,1,1)},
                            new Price {Close=7,Date=new DateTime(2015,1,1)},
                            new Price {Close=37.75,Date=new DateTime(2014,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=112.40,Year=2016},
                            new Statistic{NetProfit=1320.18,Year=2015},
                            new Statistic{NetProfit=1003.67,Year=2014},
                            new Statistic{NetProfit=1206.3,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1599599999,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1599599999,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1599599999,Date=new DateTime(2014,1,31)},
                            new Share{Amount=320000000,Date=new DateTime(2013,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.39,Median=0.39,Year=2018},
                            new Consensus{Average=0.15,Median=0.15,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bwg",
                        Prices = new Price[] 
                        { 
                            new Price {Close=2.12,Date=new DateTime(2017,1,1)},
                            new Price {Close=1.49,Date=new DateTime(2016,1,1)},
                            new Price {Close=1.69,Date=new DateTime(2015,1,1)},
                            new Price {Close=2.2,Date=new DateTime(2014,1,1)},
                            new Price {Close=1.98,Date=new DateTime(2013,1,1)},
                            new Price {Close=1.65,Date=new DateTime(2012,1,1)},
                            new Price {Close=1.22,Date=new DateTime(2011,1,1)},
                            new Price {Close=1.08,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.36,Date=new DateTime(2009,1,1)},
                            new Price {Close=4.29,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=351.54,Year=2016},
                            new Statistic{NetProfit=308.70,Year=2015},
                            new Statistic{NetProfit=202.95,Year=2014},
                            new Statistic{NetProfit=163.2,Year=2013},
                            new Statistic{NetProfit=75.85,Year=2012},
                            new Statistic{NetProfit=97.4,Year=2011},
                            new Statistic{NetProfit=41.03,Year=2010},
                            new Statistic{NetProfit=-43.82,Year=2009},
                            new Statistic{NetProfit=73.65,Year=2008},
                            new Statistic{NetProfit=106.86,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3832117512,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2280450000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1681330000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=714255819,Date=new DateTime(2013,1,31)},
                            new Share{Amount=714255819,Date=new DateTime(2012,1,31)},
                            new Share{Amount=714245000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=640000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=640000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=640000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=640000000,Date=new DateTime(2007,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.12,Median=0.12,Year=2018},
                            new Consensus{Average=0.11,Median=0.11,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bec",
                        Prices = new Price[] 
                        { 
                            new Price {Close=17.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=30,Date=new DateTime(2016,1,1)},
                            new Price {Close=51.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=46.75,Date=new DateTime(2014,1,1)},
                            new Price {Close=73.75,Date=new DateTime(2013,1,1)},
                            new Price {Close=43.25,Date=new DateTime(2012,1,1)},
                            new Price {Close=31.5,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1218.29,Year=2016},
                            new Statistic{NetProfit=2982.71,Year=2015},
                            new Statistic{NetProfit=4414.99,Year=2014},
                            new Statistic{NetProfit=5589.48,Year=2013},
                            new Statistic{NetProfit=4777.25,Year=2012},
                            new Statistic{NetProfit=3530.35,Year=2011},
                            new Statistic{NetProfit=3302.29,Year=2010}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2000000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2000000000,Date=new DateTime(2010,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.74,Median=0.74,Year=2018},
                            new Consensus{Average=0.64,Median=0.64,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpf",
                        Prices = new Price[] 
                        { 
                            new Price {Close=28.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=19.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=25.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=28.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=35.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=35,Date=new DateTime(2012,1,1)},
                            new Price {Close=21.9,Date=new DateTime(2011,1,1)},
                            new Price {Close=11.5,Date=new DateTime(2010,1,1)},
                            new Price {Close=24.18,Date=new DateTime(2009,1,1)},
                            new Price {Close=24.08,Date=new DateTime(2008,1,1)},
                            new Price {Close=5.45,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=14702.82,Year=2016},
                            new Statistic{NetProfit=11058.74,Year=2015},
                            new Statistic{NetProfit=10561.70,Year=2014},
                            new Statistic{NetProfit=7065.25,Year=2013},
                            new Statistic{NetProfit=18790,Year=2012},
                            new Statistic{NetProfit=15837.01,Year=2011},
                            new Statistic{NetProfit=13837,Year=2010},
                            new Statistic{NetProfit=10190.22,Year=2009},
                            new Statistic{NetProfit=3128.4,Year=2008},
                            new Statistic{NetProfit=1275.13,Year=2007},
                            new Statistic{NetProfit=2510.33,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=7742941932,Date=new DateTime(2016,1,31)},
                            new Share{Amount=7742941932,Date=new DateTime(2015,1,31)},
                            new Share{Amount=7742941932,Date=new DateTime(2014,1,31)},
                            new Share{Amount=7742941932,Date=new DateTime(2013,1,31)},
                            new Share{Amount=7742941932,Date=new DateTime(2012,1,31)},
                            new Share{Amount=7742941932,Date=new DateTime(2011,1,31)},
                            new Share{Amount=7048937826,Date=new DateTime(2010,1,31)},
                            new Share{Amount=7048937826,Date=new DateTime(2009,1,31)},
                            new Share{Amount=7048937826,Date=new DateTime(2008,1,31)},
                            new Share{Amount=7048937826,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bla",
                        Prices = new Price[] 
                        { 
                            new Price {Close=48.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=47.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=52,Date=new DateTime(2015,1,1)},
                            new Price {Close=61.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=69.75,Date=new DateTime(2013,1,1)},
                            new Price {Close=49,Date=new DateTime(2012,1,1)},
                            new Price {Close=28.21,Date=new DateTime(2011,1,1)},
                            new Price {Close=21.93,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=5110.30,Year=2016},
                            new Statistic{NetProfit=4108.20,Year=2015},
                            new Statistic{NetProfit=2661.75,Year=2014},
                            new Statistic{NetProfit=4380.5,Year=2013},
                            new Statistic{NetProfit=3284.37,Year=2012},
                            new Statistic{NetProfit=3417.1,Year=2011},
                            new Statistic{NetProfit=2796.48,Year=2010},
                            new Statistic{NetProfit=1185.69,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1707566000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1703810000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1697850000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1210801300,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1207399800,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1200000000,Date=new DateTime(2009,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=4.23,Median=4.23,Year=2018},
                            new Consensus{Average=3.53,Median=3.53,Year=2017} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "scb",
                        Prices = new Price[] 
                        { 
                            new Price {Close=152.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=130,Date=new DateTime(2016,1,1)},
                            new Price {Close=179.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=149,Date=new DateTime(2014,1,1)},
                            new Price {Close=179,Date=new DateTime(2013,1,1)},
                            new Price {Close=119,Date=new DateTime(2012,1,1)},
                            new Price {Close=94,Date=new DateTime(2011,1,1)},
                            new Price {Close=79.75,Date=new DateTime(2010,1,1)},
                            new Price {Close=52,Date=new DateTime(2009,1,1)},
                            new Price {Close=76,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=47612.23,Year=2016},
                            new Statistic{NetProfit=47182.41,Year=2015},
                            new Statistic{NetProfit=53334.62,Year=2014},
                            new Statistic{NetProfit=50232.79,Year=2013},
                            new Statistic{NetProfit=40219.9,Year=2012},
                            new Statistic{NetProfit=36273,Year=2011},
                            new Statistic{NetProfit=24206,Year=2010},
                            new Statistic{NetProfit=20759.72,Year=2009},
                            new Statistic{NetProfit=21413.7,Year=2008},
                            new Statistic{NetProfit=17355.96,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3395394123,Date=new DateTime(2018,1,31)},
                            new Share{Amount=3395394123,Date=new DateTime(2017,1,31)},
                            new Share{Amount=3395394123,Date=new DateTime(2016,1,31)},
                            new Share{Amount=3395394123,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3395394123,Date=new DateTime(2014,1,31)},
                            new Share{Amount=3393736429,Date=new DateTime(2013,1,31)},
                            new Share{Amount=3393808197,Date=new DateTime(2012,1,31)},
                            new Share{Amount=3393348537,Date=new DateTime(2011,1,31)},
                            new Share{Amount=3392728306,Date=new DateTime(2010,1,31)},
                            new Share{Amount=3392728306,Date=new DateTime(2009,1,31)},
                            new Share{Amount=3392728306,Date=new DateTime(2008,1,31)},
                            new Share{Amount=3392728306,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bbl",
                        Prices = new Price[] 
                        { 
                            new Price {Close=174.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=152.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=190.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=171.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=209,Date=new DateTime(2013,1,1)},
                            new Price {Close=153.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=150.75,Date=new DateTime(2011,1,1)},
                            new Price {Close=106.62,Date=new DateTime(2010,1,1)},
                            new Price {Close=66.7,Date=new DateTime(2009,1,1)},
                            new Price {Close=106.07,Date=new DateTime(2008,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=31814.84,Year=2016},
                            new Statistic{NetProfit=34180.63,Year=2015},
                            new Statistic{NetProfit=36332.18,Year=2014},
                            new Statistic{NetProfit=35905.56,Year=2013},
                            new Statistic{NetProfit=33021.46,Year=2012},
                            new Statistic{NetProfit=27337.64,Year=2011},
                            new Statistic{NetProfit=24593.42,Year=2010},
                            new Statistic{NetProfit=20764.04,Year=2009},
                            new Statistic{NetProfit=20242.99,Year=2008},
                            new Statistic{NetProfit=19217.88,Year=2007}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1908842894,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2008,1,31)},
                            new Share{Amount=1908842894,Date=new DateTime(2007,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ifs",
                        Prices = new Price[] 
                        { 
                            new Price {Close=3.43,Date=new DateTime(2017,1,1)},
                            new Price {Close=2.48,Date=new DateTime(2016,1,1)},
                            new Price {Close=3.07,Date=new DateTime(2015,1,1)},
                            new Price {Close=2.54,Date=new DateTime(2014,1,1)},
                            new Price {Close=2.96,Date=new DateTime(2013,1,1)},
                            new Price {Close=1.25,Date=new DateTime(2012,1,1)},
                            new Price {Close=1.32,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=136.83,Year=2016},
                            new Statistic{NetProfit=118.12,Year=2015},
                            new Statistic{NetProfit=138.12,Year=2014},
                            new Statistic{NetProfit=125.08,Year=2013},
                            new Statistic{NetProfit=111.71,Year=2012},
                            new Statistic{NetProfit=67.84,Year=2011},
                            new Statistic{NetProfit=84.8,Year=2010}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=470000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=470000000,Date=new DateTime(2010,1,31)}
                        },
                        Consensuses = new Consensus[] 
                        { 
                            new Consensus{Average=0.33,Median=0.33,Year=2015},
                            new Consensus{Average=0.29,Median=0.29,Year=2014} 
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ttw",
                        Prices = new Price[] 
                        { 
                            new Price {Close=10.7,Date=new DateTime(2017,1,1)},
                            new Price {Close=10.1,Date=new DateTime(2016,1,1)},
                            new Price {Close=12.3,Date=new DateTime(2015,1,1)},
                            new Price {Close=9.65,Date=new DateTime(2014,1,1)},
                            new Price {Close=10.3,Date=new DateTime(2013,1,1)},
                            new Price {Close=5.36,Date=new DateTime(2012,1,1)},
                            new Price {Close=6.15,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.34,Date=new DateTime(2010,1,1)},
                            new Price {Close=4.32,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2475.56,Year=2016},
                            new Statistic{NetProfit=2680.52,Year=2015},
                            new Statistic{NetProfit=2973.91,Year=2014},
                            new Statistic{NetProfit=2573.76,Year=2013},
                            new Statistic{NetProfit=2421.32,Year=2012},
                            new Statistic{NetProfit=2112.97,Year=2011},
                            new Statistic{NetProfit=2063,Year=2010},
                            new Statistic{NetProfit=1593.63,Year=2009},
                            new Statistic{NetProfit=1358.41,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3990000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=3990000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "singer",
                        Prices = new Price[] 
                        { 
                            new Price {Close=11.4,Date=new DateTime(2017,1,1)},
                            new Price {Close=8.1,Date=new DateTime(2016,1,1)},
                            new Price {Close=15.6,Date=new DateTime(2015,1,1)},
                            new Price {Close=16.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=19.8,Date=new DateTime(2013,1,1)},
                            new Price {Close=6.7,Date=new DateTime(2012,1,1)},
                            new Price {Close=3.44,Date=new DateTime(2011,1,1)},
                            new Price {Close=1.54,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=119.81,Year=2016},
                            new Statistic{NetProfit=143.15,Year=2015},
                            new Statistic{NetProfit=241.43,Year=2014},
                            new Statistic{NetProfit=320.57,Year=2013},
                            new Statistic{NetProfit=226.22,Year=2012},
                            new Statistic{NetProfit=142.46,Year=2011},
                            new Statistic{NetProfit=89.37,Year=2010},
                            new Statistic{NetProfit=36.53,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=270000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=270000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hmpro",
                        Prices = new Price[] 
                        { 
                            new Price {Close=10.1,Date=new DateTime(2017,1,1)},
                            new Price {Close=6.8,Date=new DateTime(2016,1,1)},
                            new Price {Close=7.64,Date=new DateTime(2015,1,1)},
                            new Price {Close=7.48,Date=new DateTime(2014,1,1)},
                            new Price {Close=13.8,Date=new DateTime(2013,1,1)},
                            new Price {Close=11.2,Date=new DateTime(2012,1,1)},
                            new Price {Close=7.02,Date=new DateTime(2011,1,1)},
                            new Price {Close=2.93,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.17,Date=new DateTime(2009,1,1)},
                            new Price {Close=1.51,Date=new DateTime(2008,1,1)},
                            new Price {Close=1.77,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=4125.20,Year=2016},
                            new Statistic{NetProfit=3498.81,Year=2015},
                            new Statistic{NetProfit=3313.33,Year=2014},
                            new Statistic{NetProfit=3068.48,Year=2013},
                            new Statistic{NetProfit=2679.47,Year=2012},
                            new Statistic{NetProfit=2005.36,Year=2011},
                            new Statistic{NetProfit=1638,Year=2010},
                            new Statistic{NetProfit=1142,Year=2009},
                            new Statistic{NetProfit=959,Year=2008},
                            new Statistic{NetProfit=710,Year=2007},
                            new Statistic{NetProfit=608,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=13151198025,Date=new DateTime(2016,1,31)},
                            new Share{Amount=13151198025,Date=new DateTime(2015,1,31)},
                            new Share{Amount=12329320000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=95895500000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=7041430018,Date=new DateTime(2012,1,31)},
                            new Share{Amount=5836700000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=4355000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=4355000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=4355000000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=4355000000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=4355000000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "sta",
                        Prices = new Price[] 
                        { 
                            new Price {Close=26.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=10.4,Date=new DateTime(2016,1,1)},
                            new Price {Close=13.6,Date=new DateTime(2015,1,1)},
                            new Price {Close=12.3,Date=new DateTime(2014,1,1)},
                            new Price {Close=18.6,Date=new DateTime(2013,1,1)},
                            new Price {Close=21.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=31.79,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.42,Date=new DateTime(2010,1,1)},
                            new Price {Close=1.41,Date=new DateTime(2009,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-757.99,Year=2016},
                            new Statistic{NetProfit=1118.03,Year=2015},
                            new Statistic{NetProfit=1037.76,Year=2014},
                            new Statistic{NetProfit=1811.6,Year=2013},
                            new Statistic{NetProfit=1378.89,Year=2012},
                            new Statistic{NetProfit=1306.249,Year=2011},
                            new Statistic{NetProfit=3852.72,Year=2010},
                            new Statistic{NetProfit=2141.99,Year=2009},
                            new Statistic{NetProfit=627.26,Year=2008}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1280000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=1280000000,Date=new DateTime(2008,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "tvo",
                        Prices = new Price[] 
                        { 
                            new Price {Close=41,Date=new DateTime(2017,1,1)},
                            new Price {Close=22.9,Date=new DateTime(2016,1,1)},
                            new Price {Close=22.3,Date=new DateTime(2015,1,1)},
                            new Price {Close=19.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=25.75,Date=new DateTime(2013,1,1)},
                            new Price {Close=19.4,Date=new DateTime(2012,1,1)},
                            new Price {Close=28,Date=new DateTime(2011,1,1)},
                            new Price {Close=16.8,Date=new DateTime(2010,1,1)},
                            new Price {Close=9.85,Date=new DateTime(2009,1,1)},
                            new Price {Close=15.7,Date=new DateTime(2008,1,1)},
                            new Price {Close=6.44,Date=new DateTime(2007,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2754.62,Year=2016},
                            new Statistic{NetProfit=1902.59,Year=2015},
                            new Statistic{NetProfit=1679.46,Year=2014},
                            new Statistic{NetProfit=959.12,Year=2013},
                            new Statistic{NetProfit=1775.31,Year=2012},
                            new Statistic{NetProfit=725.3,Year=2011},
                            new Statistic{NetProfit=1524.94,Year=2010},
                            new Statistic{NetProfit=1624.52,Year=2009},
                            new Statistic{NetProfit=749.63,Year=2008},
                            new Statistic{NetProfit=1256.39,Year=2007},
                            new Statistic{NetProfit=471.36,Year=2006}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=808610985,Date=new DateTime(2016,1,31)},
                            new Share{Amount=808610985,Date=new DateTime(2015,1,31)},
                            new Share{Amount=808610985,Date=new DateTime(2014,1,31)},
                            new Share{Amount=808610985,Date=new DateTime(2013,1,31)},
                            new Share{Amount=808610985,Date=new DateTime(2012,1,31)},
                            new Share{Amount=768753874,Date=new DateTime(2011,1,31)},
                            new Share{Amount=765404049,Date=new DateTime(2010,1,31)},
                            new Share{Amount=692500000,Date=new DateTime(2009,1,31)},
                            new Share{Amount=624510000,Date=new DateTime(2008,1,31)},
                            new Share{Amount=624510000,Date=new DateTime(2007,1,31)},
                            new Share{Amount=499610000,Date=new DateTime(2006,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "jubile",
                        Prices = new Price[] 
                        { 
                            new Price {Close=19.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=17.9,Date=new DateTime(2016,1,1)},
                            new Price {Close=34.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=22.6,Date=new DateTime(2014,1,1)},
                            new Price {Close=23,Date=new DateTime(2013,1,1)},
                            new Price {Close=11.1,Date=new DateTime(2012,1,1)},
                            new Price {Close=6.9,Date=new DateTime(2011,1,1)},
                            new Price {Close=2.8,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=157.28,Year=2016},
                            new Statistic{NetProfit=131.12,Year=2015},
                            new Statistic{NetProfit=205.12,Year=2014},
                            new Statistic{NetProfit=202.8,Year=2013},
                            new Statistic{NetProfit=165.87,Year=2012},
                            new Statistic{NetProfit=131.19,Year=2011},
                            new Statistic{NetProfit=103.73,Year=2010},
                            new Statistic{NetProfit=60.24,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=174273125,Date=new DateTime(2016,1,31)},
                            new Share{Amount=174273125,Date=new DateTime(2015,1,31)},
                            new Share{Amount=174273125,Date=new DateTime(2014,1,31)},
                            new Share{Amount=174273125,Date=new DateTime(2013,1,31)},
                            new Share{Amount=173300000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=172290000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=171120000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=170000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ait",
                        Prices = new Price[] 
                        { 
                            new Price {Close=26.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=27,Date=new DateTime(2016,1,1)},
                            new Price {Close=41,Date=new DateTime(2015,1,1)},
                            new Price {Close=25.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=67.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=52,Date=new DateTime(2012,1,1)},
                            new Price {Close=43,Date=new DateTime(2011,1,1)},
                            new Price {Close=25.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=429.39,Year=2016},
                            new Statistic{NetProfit=532.51,Year=2015},
                            new Statistic{NetProfit=658.56,Year=2014},
                            new Statistic{NetProfit=567.62,Year=2013},
                            new Statistic{NetProfit=367.59,Year=2012},
                            new Statistic{NetProfit=438.92,Year=2011},
                            new Statistic{NetProfit=388.37,Year=2010},
                            new Statistic{NetProfit=312.21,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=206320897,Date=new DateTime(2016,1,31)},
                            new Share{Amount=206320897,Date=new DateTime(2015,1,31)},
                            new Share{Amount=206320897,Date=new DateTime(2014,1,31)},
                            new Share{Amount=206320897,Date=new DateTime(2013,1,31)},
                            new Share{Amount=68773630,Date=new DateTime(2012,1,31)},
                            new Share{Amount=68773630,Date=new DateTime(2011,1,31)},
                            new Share{Amount=68773630,Date=new DateTime(2010,1,31)},
                            new Share{Amount=68773630,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "m",
                        Prices = new Price[] 
                        { 
                            new Price {Close=56.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=53.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=58.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=48.75,Date=new DateTime(2014,1,1)},
                            new Price {Close=47,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2099.76,Year=2016},
                            new Statistic{NetProfit=1856.00,Year=2015},
                            new Statistic{NetProfit=2042.38,Year=2014},
                            new Statistic{NetProfit=2039.17,Year=2013},
                            new Statistic{NetProfit=2041,Year=2012}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "hotpot",
                        Prices = new Price[] 
                        { 
                            new Price {Close=2.64,Date=new DateTime(2017,1,1)},
                            new Price {Close=2.06,Date=new DateTime(2016,1,1)},
                            new Price {Close=3.22,Date=new DateTime(2015,1,1)},
                            new Price {Close=3.16,Date=new DateTime(2014,1,1)},
                            new Price {Close=3.92,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-148.23,Year=2016},
                            new Statistic{NetProfit=-94.99,Year=2015},
                            new Statistic{NetProfit=-54.45,Year=2014},
                            new Statistic{NetProfit=42.78,Year=2013},
                            new Statistic{NetProfit=23.33,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=406000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=406000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=406000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=406000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=406000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bdms",
                        Prices = new Price[] 
                        { 
                            new Price {Close=22.2,Date=new DateTime(2017,1,1)},
                            new Price {Close=22,Date=new DateTime(2016,1,1)},
                            new Price {Close=18.6,Date=new DateTime(2015,1,1)},
                            new Price {Close=118,Date=new DateTime(2014,1,1)},
                            new Price {Close=133,Date=new DateTime(2013,1,1)},
                            new Price {Close=76.75,Date=new DateTime(2012,1,1)},
                            new Price {Close=48,Date=new DateTime(2011,1,1)},
                            new Price {Close=23.8,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=8386.48,Year=2016},
                            new Statistic{NetProfit=7917.47,Year=2015},
                            new Statistic{NetProfit=7393.52,Year=2014},
                            new Statistic{NetProfit=6261.46,Year=2013},
                            new Statistic{NetProfit=7936.95,Year=2012},
                            new Statistic{NetProfit=4385.99,Year=2011},
                            new Statistic{NetProfit=2295.06,Year=2010},
                            new Statistic{NetProfit=1725.18,Year=2009}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=15490956540,Date=new DateTime(2016,1,31)},
                            new Share{Amount=15490956540,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1545458883,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1545458883,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1545460000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1545460000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1246040000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1214500000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "true",
                        Prices = new Price[] 
                        { 
                            new Price {Close=6.55,Date=new DateTime(2017,1,1)},
                            new Price {Close=6.97,Date=new DateTime(2016,1,1)},
                            new Price {Close=13.36,Date=new DateTime(2015,1,1)},
                            new Price {Close=6.37,Date=new DateTime(2014,1,1)},
                            new Price {Close=5.84,Date=new DateTime(2013,1,1)},
                            new Price {Close=2.85,Date=new DateTime(2012,1,1)},
                            new Price {Close=3.92,Date=new DateTime(2011,1,1)},
                            new Price {Close=1.71,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-2814.35,Year=2016},
                            new Statistic{NetProfit=4411.52,Year=2015},
                            new Statistic{NetProfit=1425.28,Year=2014},
                            new Statistic{NetProfit=-9062.75,Year=2013},
                            new Statistic{NetProfit=-7427.77,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=33368195301,Date=new DateTime(2016,1,31)},
                            new Share{Amount=33368195301,Date=new DateTime(2015,1,31)},
                            new Share{Amount=33368195301,Date=new DateTime(2014,1,31)},
                            new Share{Amount=33368195301,Date=new DateTime(2013,1,31)},
                            new Share{Amount=33368195301,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "rs",
                        Prices = new Price[] 
                        { 
                            new Price {Close=9.4,Date=new DateTime(2017,1,1)},
                            new Price {Close=9.1,Date=new DateTime(2016,1,1)},
                            new Price {Close=20,Date=new DateTime(2015,1,1)},
                            new Price {Close=7.35,Date=new DateTime(2014,1,1)},
                            new Price {Close=7.35,Date=new DateTime(2013,1,1)},
                            new Price {Close=2.74,Date=new DateTime(2012,1,1)},
                            new Price {Close=3.2,Date=new DateTime(2011,1,1)},
                            new Price {Close=2,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-102.15,Year=2016},
                            new Statistic{NetProfit=121.63,Year=2015},
                            new Statistic{NetProfit=370.96,Year=2014},
                            new Statistic{NetProfit=394.49,Year=2013},
                            new Statistic{NetProfit=281.18,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=966664346,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1009940000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1022350000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=953870000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=882690000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=882650000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=708070000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=708070000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "intuch",
                        Prices = new Price[] 
                        { 
                            new Price {Close=53.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=56.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=80.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=70.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=68.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=50,Date=new DateTime(2012,1,1)},
                            new Price {Close=28.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=26.25,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=16397.61,Year=2016},
                            new Statistic{NetProfit=16077.79,Year=2015},
                            new Statistic{NetProfit=14761.26,Year=2014},
                            new Statistic{NetProfit=14567.98,Year=2013},
                            new Statistic{NetProfit=13786.74,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=3206420305,Date=new DateTime(2016,1,31)},
                            new Share{Amount=3206420305,Date=new DateTime(2015,1,31)},
                            new Share{Amount=3206420305,Date=new DateTime(2014,1,31)},
                            new Share{Amount=3206420305,Date=new DateTime(2013,1,31)},
                            new Share{Amount=3206420305,Date=new DateTime(2012,1,31)},
                            new Share{Amount=3206420305,Date=new DateTime(2011,1,31)},
                            new Share{Amount=3201080000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=3201080000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "cpall",
                        Prices = new Price[] 
                        { 
                            new Price {Close=60.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=40.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=41.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=39.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=47.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=28.25,Date=new DateTime(2012,1,1)},
                            new Price {Close=19.25,Date=new DateTime(2011,1,1)},
                            new Price {Close=11.4,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=16676.51,Year=2016},
                            new Statistic{NetProfit=13682.46,Year=2015},
                            new Statistic{NetProfit=10153.77,Year=2014},
                            new Statistic{NetProfit=10536.99,Year=2013},
                            new Statistic{NetProfit=11023.23,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=8983101348,Date=new DateTime(2016,1,31)},
                            new Share{Amount=8983101348,Date=new DateTime(2015,1,31)},
                            new Share{Amount=8983101348,Date=new DateTime(2014,1,31)},
                            new Share{Amount=8983101348,Date=new DateTime(2013,1,31)},
                            new Share{Amount=8983101348,Date=new DateTime(2012,1,31)},
                            new Share{Amount=4493150000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=4493150000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=4493150000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "makro",
                        Prices = new Price[] 
                        { 
                            new Price {Close=34.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=34.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=36.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=31.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=22.3,Date=new DateTime(2013,1,1)},
                            new Price {Close=12.8,Date=new DateTime(2012,1,1)},
                            new Price {Close=7.1,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.3,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=5412.52,Year=2016},
                            new Statistic{NetProfit=5378.48,Year=2015},
                            new Statistic{NetProfit=4884.89,Year=2014},
                            new Statistic{NetProfit=4298.58,Year=2013},
                            new Statistic{NetProfit=3555.92,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4800000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=4800000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "grammy",
                        Prices = new Price[] 
                        { 
                            new Price {Close=10.3,Date=new DateTime(2017,1,1)},
                            new Price {Close=7.6,Date=new DateTime(2016,1,1)},
                            new Price {Close=14.3,Date=new DateTime(2015,1,1)},
                            new Price {Close=16.6,Date=new DateTime(2014,1,1)},
                            new Price {Close=16.59,Date=new DateTime(2013,1,1)},
                            new Price {Close=16.97,Date=new DateTime(2012,1,1)},
                            new Price {Close=13.78,Date=new DateTime(2011,1,1)},
                            new Price {Close=12.75,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-520.15,Year=2016},
                            new Statistic{NetProfit=-1145.48,Year=2015},
                            new Statistic{NetProfit=-2314.01,Year=2014},
                            new Statistic{NetProfit=-1282.71,Year=2013},
                            new Statistic{NetProfit=-347.48,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=819949729,Date=new DateTime(2016,1,31)},
                            new Share{Amount=819949729,Date=new DateTime(2015,1,31)},
                            new Share{Amount=819949729,Date=new DateTime(2014,1,31)},
                            new Share{Amount=636317936,Date=new DateTime(2013,1,31)},
                            new Share{Amount=530260000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=530260000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=530260000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=530260000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mcot",
                        Prices = new Price[] 
                        { 
                            new Price {Close=15.2,Date=new DateTime(2017,1,1)},
                            new Price {Close=8.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=15.8,Date=new DateTime(2015,1,1)},
                            new Price {Close=28.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=46.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=27.75,Date=new DateTime(2012,1,1)},
                            new Price {Close=29,Date=new DateTime(2011,1,1)},
                            new Price {Close=22.4,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-734.89,Year=2016},
                            new Statistic{NetProfit=57.81,Year=2015},
                            new Statistic{NetProfit=503.79,Year=2014},
                            new Statistic{NetProfit=1526.93,Year=2013},
                            new Statistic{NetProfit=1758.87,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=687099210,Date=new DateTime(2016,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2015,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2014,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2013,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2012,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2011,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2010,1,31)},
                            new Share{Amount=687099210,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "top",
                        Prices = new Price[] 
                        { 
                            new Price {Close=71.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=64.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=51.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=52,Date=new DateTime(2014,1,1)},
                            new Price {Close=75.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=64.25,Date=new DateTime(2012,1,1)},
                            new Price {Close=69.75,Date=new DateTime(2011,1,1)},
                            new Price {Close=40.75,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=21221.91,Year=2016},
                            new Statistic{NetProfit=12181.37,Year=2015},
                            new Statistic{NetProfit=-4025.89,Year=2014},
                            new Statistic{NetProfit=10393.53,Year=2013},
                            new Statistic{NetProfit=12319.79,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2040027873,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2040027873,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aav",
                        Prices = new Price[] 
                        { 
                            new Price {Close=6.15,Date=new DateTime(2017,1,1)},
                            new Price {Close=5.7,Date=new DateTime(2016,1,1)},
                            new Price {Close=5.45,Date=new DateTime(2015,1,1)},
                            new Price {Close=3.56,Date=new DateTime(2014,1,1)},
                            new Price {Close=6.1,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1869.46,Year=2016},
                            new Statistic{NetProfit=1078.48,Year=2015},
                            new Statistic{NetProfit=183.18,Year=2014},
                            new Statistic{NetProfit=1042.76,Year=2013},
                            new Statistic{NetProfit=15648.57,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=4850000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=4850000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=4850000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=4850000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=4850000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "nok",
                        Prices = new Price[] 
                        { 
                            new Price {Close=4.78,Date=new DateTime(2017,1,1)},
                            new Price {Close=4.88,Date=new DateTime(2016,1,1)},
                            new Price {Close=10.41,Date=new DateTime(2015,1,1)},
                            new Price {Close=17.6,Date=new DateTime(2014,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=-2795.09,Year=2016},
                            new Statistic{NetProfit=-726.10,Year=2015},
                            new Statistic{NetProfit=-471.66,Year=2014},
                            new Statistic{NetProfit=1066.10,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=625000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=625000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=625000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=625000000,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "kbank",
                        Prices = new Price[] 
                        { 
                            new Price {Close=188.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=169.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=222,Date=new DateTime(2015,1,1)},
                            new Price {Close=171,Date=new DateTime(2014,1,1)},
                            new Price {Close=197.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=129,Date=new DateTime(2012,1,1)},
                            new Price {Close=118.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=82.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=40174.10,Year=2016},
                            new Statistic{NetProfit=39473.64,Year=2015},
                            new Statistic{NetProfit=46153.41,Year=2014},
                            new Statistic{NetProfit=41324.81,Year=2013},
                            new Statistic{NetProfit=35259.80,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2393260193,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2012,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2011,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2010,1,31)},
                            new Share{Amount=2393260193,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bay",
                        Prices = new Price[] 
                        { 
                            new Price {Close=39.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=31,Date=new DateTime(2016,1,1)},
                            new Price {Close=68.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=32.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=33.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=22.2,Date=new DateTime(2012,1,1)},
                            new Price {Close=25.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=19.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=21404.03,Year=2016},
                            new Statistic{NetProfit=18634.18,Year=2015},
                            new Statistic{NetProfit=14169.53,Year=2014},
                            new Statistic{NetProfit=11866.65,Year=2013},
                            new Statistic{NetProfit=14625.33,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=7355761773,Date=new DateTime(2016,1,31)},
                            new Share{Amount=7355761773,Date=new DateTime(2015,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2014,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2013,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2012,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2011,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2010,1,31)},
                            new Share{Amount=6074143747,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "samart",
                        Prices = new Price[] 
                        { 
                            new Price {Close=16.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=19,Date=new DateTime(2016,1,1)},
                            new Price {Close=40.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=14.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=13.7,Date=new DateTime(2013,1,1)},
                            new Price {Close=8.05,Date=new DateTime(2012,1,1)},
                            new Price {Close=9,Date=new DateTime(2011,1,1)},
                            new Price {Close=5.55,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=13883.73,Year=2016},
                            new Statistic{NetProfit=18586.43,Year=2015},
                            new Statistic{NetProfit=24195.81,Year=2014},
                            new Statistic{NetProfit=22433.56,Year=2013},
                            new Statistic{NetProfit=17099.57,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1006503910,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1006503910,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1006503910,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1006503910,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1002100000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=990650000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=985630000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=980310000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "thcom",
                        Prices = new Price[] 
                        { 
                            new Price {Close=22.1,Date=new DateTime(2017,1,1)},
                            new Price {Close=26.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=39,Date=new DateTime(2015,1,1)},
                            new Price {Close=37.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=23.8,Date=new DateTime(2013,1,1)},
                            new Price {Close=12.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=5.65,Date=new DateTime(2011,1,1)},
                            new Price {Close=6.75,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1611.77,Year=2016},
                            new Statistic{NetProfit=2122.15,Year=2015},
                            new Statistic{NetProfit=1600.88,Year=2014},
                            new Statistic{NetProfit=1127.62,Year=2013},
                            new Statistic{NetProfit=173.90,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1095937540,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1095937540,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "gfpt",
                        Prices = new Price[] 
                        { 
                            new Price {Close=14.8,Date=new DateTime(2017,1,1)},
                            new Price {Close=12.2,Date=new DateTime(2016,1,1)},
                            new Price {Close=15.7,Date=new DateTime(2015,1,1)},
                            new Price {Close=13.1,Date=new DateTime(2014,1,1)},
                            new Price {Close=8.4,Date=new DateTime(2013,1,1)},
                            new Price {Close=10.9,Date=new DateTime(2012,1,1)},
                            new Price {Close=8.1,Date=new DateTime(2011,1,1)},
                            new Price {Close=4.08,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1643.70,Year=2016},
                            new Statistic{NetProfit=1194.92,Year=2015},
                            new Statistic{NetProfit=1779.59,Year=2014},
                            new Statistic{NetProfit=1503.62,Year=2013},
                            new Statistic{NetProfit=40.83,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1253821000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1253821000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "lpn",
                        Prices = new Price[] 
                        { 
                            new Price {Close=12,Date=new DateTime(2017,1,1)},
                            new Price {Close=14.7,Date=new DateTime(2016,1,1)},
                            new Price {Close=21,Date=new DateTime(2015,1,1)},
                            new Price {Close=14.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=22,Date=new DateTime(2013,1,1)},
                            new Price {Close=13.9,Date=new DateTime(2012,1,1)},
                            new Price {Close=8.7,Date=new DateTime(2011,1,1)},
                            new Price {Close=6.6,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2176.23,Year=2016},
                            new Statistic{NetProfit=2413.40,Year=2015},
                            new Statistic{NetProfit=2021.42,Year=2014},
                            new Statistic{NetProfit=2328.58,Year=2013},
                            new Statistic{NetProfit=2216.79,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1475698768,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1475698768,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "spali",
                        Prices = new Price[] 
                        { 
                            new Price {Close=24.2,Date=new DateTime(2017,1,1)},
                            new Price {Close=18.2,Date=new DateTime(2016,1,1)},
                            new Price {Close=24.4,Date=new DateTime(2015,1,1)},
                            new Price {Close=15.9,Date=new DateTime(2014,1,1)},
                            new Price {Close=19.6,Date=new DateTime(2013,1,1)},
                            new Price {Close=14.1,Date=new DateTime(2012,1,1)},
                            new Price {Close=9.85,Date=new DateTime(2011,1,1)},
                            new Price {Close=6,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=4886.53,Year=2016},
                            new Statistic{NetProfit=4348.72,Year=2015},
                            new Statistic{NetProfit=4478.11,Year=2014},
                            new Statistic{NetProfit=2882.21,Year=2013},
                            new Statistic{NetProfit=2743.52,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1716553249,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1716553249,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "robins",
                        Prices = new Price[] 
                        { 
                            new Price {Close=58,Date=new DateTime(2017,1,1)},
                            new Price {Close=38.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=44.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=44.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=70.25,Date=new DateTime(2013,1,1)},
                            new Price {Close=42,Date=new DateTime(2012,1,1)},
                            new Price {Close=20.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=10.3,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2815.08,Year=2016},
                            new Statistic{NetProfit=2153.04,Year=2015},
                            new Statistic{NetProfit=1927.49,Year=2014},
                            new Statistic{NetProfit=1985.71,Year=2013},
                            new Statistic{NetProfit=2063.22,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1110661133,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1110661133,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "egco",
                        Prices = new Price[] 
                        { 
                            new Price {Close=202,Date=new DateTime(2017,1,1)},
                            new Price {Close=166.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=163,Date=new DateTime(2015,1,1)},
                            new Price {Close=126.5,Date=new DateTime(2014,1,1)},
                            new Price {Close=152,Date=new DateTime(2013,1,1)},
                            new Price {Close=91.5,Date=new DateTime(2012,1,1)},
                            new Price {Close=108.5,Date=new DateTime(2011,1,1)},
                            new Price {Close=79,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2963.37,Year=2016},
                            new Statistic{NetProfit=8320.80,Year=2015},
                            new Statistic{NetProfit=4319.18,Year=2014},
                            new Statistic{NetProfit=7666.98,Year=2013},
                            new Statistic{NetProfit=6913.74,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=526465000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=526465000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "glow",
                        Prices = new Price[] 
                        { 
                            new Price {Close=78,Date=new DateTime(2017,1,1)},
                            new Price {Close=76.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=91.25,Date=new DateTime(2015,1,1)},
                            new Price {Close=67.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=79.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=55.75,Date=new DateTime(2012,1,1)},
                            new Price {Close=41.25,Date=new DateTime(2011,1,1)},
                            new Price {Close=31,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=8953.13,Year=2016},
                            new Statistic{NetProfit=8355.42,Year=2015},
                            new Statistic{NetProfit=9138.89,Year=2014},
                            new Statistic{NetProfit=7214.44,Year=2013},
                            new Statistic{NetProfit=5559.57,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1462865035,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1462865035,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ratch",
                        Prices = new Price[] 
                        { 
                            new Price {Close=51,Date=new DateTime(2017,1,1)},
                            new Price {Close=49.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=60,Date=new DateTime(2015,1,1)},
                            new Price {Close=48,Date=new DateTime(2014,1,1)},
                            new Price {Close=60.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=44,Date=new DateTime(2012,1,1)},
                            new Price {Close=40.25,Date=new DateTime(2011,1,1)},
                            new Price {Close=34.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=6165.72,Year=2016},
                            new Statistic{NetProfit=3187.87,Year=2015},
                            new Statistic{NetProfit=6279.03,Year=2014},
                            new Statistic{NetProfit=6186.85,Year=2013},
                            new Statistic{NetProfit=7726.27,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1450000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2010,1,31)},
                            new Share{Amount=1450000000,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ktc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=140.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=28.75,Date=new DateTime(2016,1,1)},
                            new Price {Close=28.75,Date=new DateTime(2015,1,1)},
                            new Price {Close=28.75,Date=new DateTime(2014,1,1)},
                            new Price {Close=41.5,Date=new DateTime(2013,1,1)},
                            new Price {Close=14.8,Date=new DateTime(2012,1,1)},
                            new Price {Close=12.2,Date=new DateTime(2011,1,1)},
                            new Price {Close=12.5,Date=new DateTime(2010,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2494.71,Year=2016},
                            new Statistic{NetProfit=2072.61,Year=2015},
                            new Statistic{NetProfit=1754.98,Year=2014},
                            new Statistic{NetProfit=1282.63,Year=2013},
                            new Statistic{NetProfit=255.00,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=257833407,Date=new DateTime(2016,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2015,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2014,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2013,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2012,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2011,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2010,1,31)},
                            new Share{Amount=257833407,Date=new DateTime(2009,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "mfec",
                        Prices = new Price[] 
                        { 
                            new Price {Close=5.8,Date=new DateTime(2017,1,1)},
                            new Price {Close=4.98,Date=new DateTime(2016,1,1)},
                            new Price {Close=8.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=6.1,Date=new DateTime(2014,1,1)},
                            new Price {Close=6.3,Date=new DateTime(2013,1,1)},
                            new Price {Close=4.78,Date=new DateTime(2012,1,1)},
                            new Price {Close=4.88,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=221.77,Year=2016},
                            new Statistic{NetProfit=196.53,Year=2015},
                            new Statistic{NetProfit=270.43,Year=2014},
                            new Statistic{NetProfit=232.21,Year=2013},
                            new Statistic{NetProfit=182.33,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=441453555,Date=new DateTime(2016,1,31)},
                            new Share{Amount=441453555,Date=new DateTime(2015,1,31)},
                            new Share{Amount=441453555,Date=new DateTime(2014,1,31)},
                            new Share{Amount=441453555,Date=new DateTime(2013,1,31)},
                            new Share{Amount=440400000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=439350000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=438300000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aeonts",
                        Prices = new Price[] 
                        { 
                            new Price {Close=100,Date=new DateTime(2017,1,1)},
                            new Price {Close=93,Date=new DateTime(2016,1,1)},
                            new Price {Close=110,Date=new DateTime(2015,1,1)},
                            new Price {Close=87.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=92,Date=new DateTime(2013,1,1)},
                            new Price {Close=30,Date=new DateTime(2012,1,1)},
                            new Price {Close=32.75,Date=new DateTime(2011,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2403.46,Year=2016},
                            new Statistic{NetProfit=2446.36,Year=2015},
                            new Statistic{NetProfit=2417.53,Year=2014},
                            new Statistic{NetProfit=2501.44,Year=2013},
                            new Statistic{NetProfit=1688.47,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=250000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2012,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2011,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2010,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "tkn",
                        Prices = new Price[] 
                        { 
                            new Price {Close=26.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=10.3,Date=new DateTime(2016,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=781.85,Year=2016},
                            new Statistic{NetProfit=396.95,Year=2015}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1380000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1380000000,Date=new DateTime(2015,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "oishi",
                        Prices = new Price[] 
                        { 
                            new Price {Close=132,Date=new DateTime(2017,1,1)},
                            new Price {Close=65,Date=new DateTime(2016,1,1)},
                            new Price {Close=78,Date=new DateTime(2015,1,1)},
                            new Price {Close=78.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=170,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=887.21,Year=2016},
                            new Statistic{NetProfit=712.19,Year=2015},
                            new Statistic{NetProfit=524.94,Year=2014},
                            new Statistic{NetProfit=455.57,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=187500000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=187500000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=187500000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=187500000,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "bh",
                        Prices = new Price[] 
                        { 
                            new Price {Close=179,Date=new DateTime(2017,1,1)},
                            new Price {Close=220,Date=new DateTime(2016,1,1)},
                            new Price {Close=156,Date=new DateTime(2015,1,1)},
                            new Price {Close=84,Date=new DateTime(2014,1,1)},
                            new Price {Close=79,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=3626.17,Year=2016},
                            new Statistic{NetProfit=3435.83,Year=2015},
                            new Statistic{NetProfit=2730.30,Year=2014},
                            new Statistic{NetProfit=2520.78,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=728688857,Date=new DateTime(2018,1,31)},
                            new Share{Amount=728688857,Date=new DateTime(2017,1,31)},
                            new Share{Amount=728688857,Date=new DateTime(2016,1,31)},
                            new Share{Amount=728688857,Date=new DateTime(2015,1,31)},
                            new Share{Amount=728688857,Date=new DateTime(2014,1,31)},
                            new Share{Amount=728688857,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ntv",
                        Prices = new Price[] 
                        { 
                            new Price {Close=51,Date=new DateTime(2017,1,1)},
                            new Price {Close=39,Date=new DateTime(2016,1,1)},
                            new Price {Close=31.5,Date=new DateTime(2015,1,1)},
                            new Price {Close=24,Date=new DateTime(2014,1,1)},
                            new Price {Close=25.75,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=317.39,Year=2016},
                            new Statistic{NetProfit=298.26,Year=2015},
                            new Statistic{NetProfit=265.39,Year=2014},
                            new Statistic{NetProfit=241.22,Year=2013},
                            new Statistic{NetProfit=245.86,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=160000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=160000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=160000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=160000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=160000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "kcar",
                        Prices = new Price[] 
                        { 
                            new Price {Close=12.4,Date=new DateTime(2017,1,1)},
                            new Price {Close=9.4,Date=new DateTime(2016,1,1)},
                            new Price {Close=11.2,Date=new DateTime(2015,1,1)},
                            new Price {Close=10.4,Date=new DateTime(2014,1,1)},
                            new Price {Close=16.6,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=330.60,Year=2016},
                            new Statistic{NetProfit=203.44,Year=2015},
                            new Statistic{NetProfit=213.71,Year=2014},
                            new Statistic{NetProfit=273.16,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=250000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=250000000,Date=new DateTime(2013,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "stpi",
                        Prices = new Price[] 
                        { 
                            new Price {Close=10,Date=new DateTime(2017,1,1)},
                            new Price {Close=9.95,Date=new DateTime(2016,1,1)},
                            new Price {Close=18.09,Date=new DateTime(2015,1,1)},
                            new Price {Close=15.82,Date=new DateTime(2014,1,1)},
                            new Price {Close=16.88,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1365.88,Year=2016},
                            new Statistic{NetProfit=2594.78,Year=2015},
                            new Statistic{NetProfit=2627.45,Year=2014},
                            new Statistic{NetProfit=1908.52,Year=2013},
                            new Statistic{NetProfit=1089.76,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1624831478,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1624831478,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1624831478,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1624831478,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1624831478,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "gpsc",
                        Prices = new Price[] 
                        { 
                            new Price {Close=35.75,Date=new DateTime(2017,1,1)},
                            new Price {Close=22.7,Date=new DateTime(2016,1,1)},
                            new Price {Close=27,Date=new DateTime(2015,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=2699.90,Year=2016},
                            new Statistic{NetProfit=1905.98,Year=2015}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1498300800,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1498300800,Date=new DateTime(2015,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "ba",
                        Prices = new Price[] 
                        { 
                            new Price {Close=22,Date=new DateTime(2017,1,1)},
                            new Price {Close=24.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=21.8,Date=new DateTime(2015,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1768.41,Year=2016},
                            new Statistic{NetProfit=1796.86,Year=2015},
                            new Statistic{NetProfit=351.11,Year=2014}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2100000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2100000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2100000000,Date=new DateTime(2014,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "thai",
                        Prices = new Price[] 
                        { 
                            new Price {Close=21.5,Date=new DateTime(2017,1,1)},
                            new Price {Close=8.25,Date=new DateTime(2016,1,1)},
                            new Price {Close=15.3,Date=new DateTime(2015,1,1)},
                            new Price {Close=14.1,Date=new DateTime(2014,1,1)},
                            new Price {Close=23.1,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=15.14,Year=2016},
                            new Statistic{NetProfit=-13067.67,Year=2015},
                            new Statistic{NetProfit=-15611.62,Year=2014},
                            new Statistic{NetProfit=-12047.37,Year=2013},
                            new Statistic{NetProfit=6228.97,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=2182771917,Date=new DateTime(2016,1,31)},
                            new Share{Amount=2182771917,Date=new DateTime(2015,1,31)},
                            new Share{Amount=2182771917,Date=new DateTime(2014,1,31)},
                            new Share{Amount=2182771917,Date=new DateTime(2013,1,31)},
                            new Share{Amount=2182771917,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "centel",
                        Prices = new Price[] 
                        { 
                            new Price {Close=37.25,Date=new DateTime(2017,1,1)},
                            new Price {Close=39.5,Date=new DateTime(2016,1,1)},
                            new Price {Close=34,Date=new DateTime(2015,1,1)},
                            new Price {Close=27.25,Date=new DateTime(2014,1,1)},
                            new Price {Close=32,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=1849.55,Year=2016},
                            new Statistic{NetProfit=1675.68,Year=2015},
                            new Statistic{NetProfit=1188.49,Year=2014},
                            new Statistic{NetProfit=1321.92,Year=2013},
                            new Statistic{NetProfit=1580.77,Year=2012}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=1350000000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=1350000000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=1350000000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=1350000000,Date=new DateTime(2013,1,31)},
                            new Share{Amount=1350000000,Date=new DateTime(2012,1,31)}
                        }
                    },
                    new BackupStockDE()
                    {
                        Quote = "aot",
                        Prices = new Price[] 
                        { 
                            new Price {Close=41.4,Date=new DateTime(2017,1,1)},
                            new Price {Close=37.8,Date=new DateTime(2016,1,1)},
                            new Price {Close=32.4,Date=new DateTime(2015,1,1)},
                            new Price {Close=17.15,Date=new DateTime(2014,1,1)},
                            new Price {Close=10.6,Date=new DateTime(2013,1,1)}
                        },
                        Statistics = new Statistic[]
                        {
                            new Statistic{NetProfit=19571.46,Year=2016},
                            new Statistic{NetProfit=18728.65,Year=2015},
                            new Statistic{NetProfit=12220.37,Year=2014},
                            new Statistic{NetProfit=16347.35,Year=2013}
                        },
                        Shares = new Share[] 
                        {
                            new Share{Amount=14285700000,Date=new DateTime(2016,1,31)},
                            new Share{Amount=14285700000,Date=new DateTime(2015,1,31)},
                            new Share{Amount=14285700000,Date=new DateTime(2014,1,31)},
                            new Share{Amount=14285700000,Date=new DateTime(2013,1,31)}
                        }
                    }
                };
            }
        }
    }
}