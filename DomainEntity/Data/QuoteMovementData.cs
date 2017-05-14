using System.Collections.Generic;
using System;

namespace StockCore.DomainEntity.Data
{
    public class QuoteMovementData
    {
        public static IEnumerable<QuoteMovement> DataV2
        {
            get
            {
                return new List<QuoteMovement>()
                {
                    new QuoteMovement()
                    {
                        Quote = "ptt",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2005,05,17),Price = 195,Volumn = 100,Amount = 19500},
                                SellOrder = new Order(){Date = new DateTime(2005,06,06),Price = 208,Volumn = 100,Amount = 20800}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2005,10,20),Price = 222,Volumn = 400,Amount = 88800},
                                SellOrder = new Order(){Date = new DateTime(2006,01,06),Price = 238,Volumn = 400,Amount = 95200}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2008,02,26),Price = 336,Volumn = 200,Amount = 67200},
                                SellOrder = new Order(){Date = new DateTime(2011,04,19),Price = 378,Volumn = 200,Amount = 75600}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2008,08,07),Price = 242,Volumn = 100,Amount = 24200},
                                SellOrder = new Order(){Date = new DateTime(2008,08,08),Price = 262,Volumn = 100,Amount = 26200}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2008,09,04),Price = 242,Volumn = 100,Amount = 24200},
                                SellOrder = new Order(){Date = new DateTime(2009,10,12),Price = 269,Volumn = 100,Amount = 26900}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,08,19),Price = 256,Volumn = 100,Amount = 25600},
                                SellOrder = new Order(){Date = new DateTime(2010,11,04),Price = 326,Volumn = 100,Amount = 32600}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,09,27),Price = 276,Volumn = 200,Amount = 55293},
                                SellOrder = new Order(){Date = new DateTime(2012,02,02),Price = 343,Volumn = 200,Amount = 68600}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,10,29),Price = 314,Volumn = 200,Amount = 62906},
                                SellOrder = new Order(){Date = new DateTime(2014,09,23),Price = 358,Volumn = 200,Amount = 71479}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,01,31),Price = 272,Volumn = 200,Amount = 54492},
                                SellOrder = new Order(){Date = new DateTime(2014,03,05),Price = 303,Volumn = 200,Amount = 60498}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,10,05),Price = 249,Volumn = 300,Amount = 74826},
                                SellOrder = new Order(){Date = new DateTime(2016,03,07),Price = 287,Volumn = 300,Amount = 85955}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "work",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,04,30),Price = 21.9,Volumn = 2240,Amount = 49135},
                                SellOrder = new Order(){Date = new DateTime(2014,11,13),Price = 39.43,Volumn = 2800,Amount = 110413}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,04,30),Price = 21.9,Volumn = 60,Amount = 1316}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,06,05),Price = 21.5,Volumn = 2457,Amount = 52910},
                                SellOrder = new Order(){Date = new DateTime(2015,09,04),Price = 43.5,Volumn = 4300,Amount = 186734}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,06,05),Price = 21.5,Volumn = 43,Amount = 926}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,06,06),Price = 21,Volumn = 2500,Amount = 52584}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,06,14),Price = 20,Volumn = 2500,Amount = 50080}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2008,09,15),Price = 8.35,Volumn = 1000,Amount = 8363}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bbl",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2005,10,20),Price = 98,Volumn = 500,Amount = 49110},
                                SellOrder = new Order(){Date = new DateTime(2005,11,21),Price = 100,Volumn = 500,Amount = 49888}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2006,05,31),Price = 103,Volumn = 500,Amount = 51616},
                                SellOrder = new Order(){Date = new DateTime(2006,09,18),Price = 111,Volumn = 500,Amount = 55375}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,10,22),Price = 116,Volumn = 400,Amount = 46474},
                                SellOrder = new Order(){Date = new DateTime(2008,02,14),Price = 126,Volumn = 400,Amount = 50319}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,01,21),Price = 196,Volumn = 300,Amount = 58899}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,07,24),Price = 169,Volumn = 400,Amount = 67714},
                                SellOrder = new Order(){Date = new DateTime(2017,03,17),Price = 184.5,Volumn = 400,Amount = 73676}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "pttep",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,05,25),Price = 139,Volumn = 100,Amount = 13922},
                                SellOrder = new Order(){Date = new DateTime(2010,06,16),Price = 143,Volumn = 100,Amount = 14277}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,08,25),Price = 144,Volumn = 100,Amount = 14423},
                                SellOrder = new Order(){Date = new DateTime(2010,09,27),Price = 150,Volumn = 100,Amount = 14976}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,08,08),Price = 164,Volumn = 300,Amount = 49283},
                                SellOrder = new Order(){Date = new DateTime(2012,02,22),Price = 185,Volumn = 300,Amount = 55411}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,10,01),Price = 160,Volumn = 400,Amount = 64108}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "prin",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,07,05),Price = 2.28,Volumn = 8000,Amount = 18269},
                                SellOrder = new Order(){Date = new DateTime(2010,07,13),Price = 2.8,Volumn = 8000,Amount = 22364}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,09,14),Price = 2.76,Volumn = 3700,Amount = 10228}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,10,08),Price = 2.56,Volumn = 4000,Amount = 10256}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,10,20),Price = 2.32,Volumn = 4455,Amount = 10351},
                                SellOrder = new Order(){Date = new DateTime(2013,01,18),Price = 2.36,Volumn = 4900,Amount = 11511}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,10,20),Price = 2.32,Volumn = 45,Amount = 106}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,11,04),Price = 2.1,Volumn = 4545,Amount = 9561},
                                SellOrder = new Order(){Date = new DateTime(2013,01,07),Price = 2.14,Volumn = 5000,Amount = 10647}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,11,04),Price = 2.1,Volumn = 255,Amount = 535}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,06,10),Price = 2,Volumn = 25000,Amount = 50084},
                                SellOrder = new Order(){Date = new DateTime(2015,02,11),Price = 2.4,Volumn = 25000,Amount = 59904}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,08,13),Price = 1.44,Volumn = 35000,Amount = 50485},
                                SellOrder = new Order(){Date = new DateTime(2014,06,12),Price = 1.61,Volumn = 35000,Amount = 56255}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "earth",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,05,16),Price = 4.72,Volumn = 12000,Amount = 56731},
                                SellOrder = new Order(){Date = new DateTime(2014,08,13),Price = 7.05,Volumn = 12000,Amount = 84457}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,08,21),Price = 5.65,Volumn = 9000,Amount = 50936},
                                SellOrder = new Order(){Date = new DateTime(2014,07,25),Price = 6.35,Volumn = 9000,Amount = 57054}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,10,03),Price = 5.35,Volumn = 13000,Amount = 69667}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,21),Price = 4.54,Volumn = 17600,Amount = 80038}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,12),Price = 1.98,Volumn = 36000,Amount = 71400}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "aav",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,12),Price = 5.95,Volumn = 12000,Amount = 71520}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "tvo",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,04,04),Price = 34.25,Volumn = 2300,Amount = 78907}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "hmpro",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,24),Price = 9.6,Volumn = 8300,Amount = 79814}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "cpf",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,01,22),Price = 25.25,Volumn = 2800,Amount = 70819},
                                SellOrder = new Order(){Date = new DateTime(2016,07,03),Price = 29.5,Volumn = 2800,Amount = 82461}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,03,10),Price = 21.8,Volumn = 3200,Amount = 69878}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,07,24),Price = 21.5,Volumn = 3300,Amount = 71070},
                                SellOrder = new Order(){Date = new DateTime(2016,04,12),Price = 25,Volumn = 3300,Amount = 82361}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,31),Price = 27.75,Volumn = 2800,Amount = 77831}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bwg",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,08,19),Price = 1.47,Volumn = 28000,Amount = 41229},
                                SellOrder = new Order(){Date = new DateTime(2012,11,14),Price = 1.62,Volumn = 28000,Amount = 45287}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,06,13),Price = 1.66,Volumn = 30000,Amount = 49880},
                                SellOrder = new Order(){Date = new DateTime(2013,01,21),Price = 1.92,Volumn = 30000,Amount = 57503}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,13),Price = 2.1,Volumn = 38000,Amount = 79934}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bec",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,11,11),Price = 56,Volumn = 900,Amount = 50485}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,01,07),Price = 47.25,Volumn = 1000,Amount = 47330},
                                SellOrder = new Order(){Date = new DateTime(2014,02,17),Price = 53.75,Volumn = 1000,Amount = 53659}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,05,23),Price = 49.75,Volumn = 1000,Amount = 49834}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,04,23),Price = 41,Volumn = 1700,Amount = 69818}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,06,03),Price = 24.1,Volumn = 2900,Amount = 70008}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,12,29),Price = 16.5,Volumn = 4300,Amount = 71070},
                                SellOrder = new Order(){Date = new DateTime(2017,05,02),Price = 18.7,Volumn = 4300,Amount = 80275}
                            }
                        }
                    }
                };
            }
        }
    }
}