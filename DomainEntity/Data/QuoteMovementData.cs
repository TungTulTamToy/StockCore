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
                                BuyOrder = new Order(){Date = new DateTime(2017,05,12),Price = 1.98,Volumn = 36000,Amount = 71399.73}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,15),Price = 2.3,Volumn = 34000,Amount = 78331.35}
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
                                BuyOrder = new Order(){Date = new DateTime(2017,05,12),Price = 5.95,Volumn = 12000,Amount = 71519.94}
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
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,06,09),Price = 30.50,Volumn = 2300,Amount = 70267.84}
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
                                BuyOrder = new Order(){Date = new DateTime(2015,03,10),Price = 21.8,Volumn = 3200,Amount = 69878},
                                SellOrder = new Order(){Date = new DateTime(2015,05,20),Price = 24.9,Volumn = 3200,Amount = 79545}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,07,24),Price = 21.5,Volumn = 3300,Amount = 71070},
                                SellOrder = new Order(){Date = new DateTime(2016,04,12),Price = 25,Volumn = 3300,Amount = 82361}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,31),Price = 27.75,Volumn = 2800,Amount = 77831}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,24),Price = 25,Volumn = 2800,Amount = 70117.59}
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
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,31),Price = 1.87,Volumn = 37000,Amount = 69306.23}
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
                                SellOrder = new Order(){Date = new DateTime(2017,05,02),Price = 18.7,Volumn = 4300,Amount = 80274.92}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bjchi",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,09,09),Price = 9.69,Volumn = 7200,Amount = 69868}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,12,25),Price = 8.19,Volumn = 8800,Amount = 72172}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,10,13),Price = 5.35,Volumn = 13000,Amount = 69667}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "ivl",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,08,16),Price = 40.25,Volumn = 1000,Amount = 40315}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,10,08),Price = 28.25,Volumn = 1800,Amount = 50936},
                                SellOrder = new Order(){Date = new DateTime(2016,06,03),Price = 32.45,Volumn = 1800,Amount = 58401}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,02,12),Price = 24.7,Volumn = 2800,Amount = 69277},
                                SellOrder = new Order(){Date = new DateTime(2014,07,03),Price = 29.5,Volumn = 2800,Amount = 82461}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,10,13),Price = 25.5,Volumn = 2800,Amount = 71521},
                                SellOrder = new Order(){Date = new DateTime(2016,11,10),Price = 32.25,Volumn = 2800,Amount = 90155}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "advanc",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,02,22),Price = 82.25,Volumn = 400,Amount = 32953},
                                SellOrder = new Order(){Date = new DateTime(2011,04,27),Price = 92,Volumn = 400,Amount = 36741}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,02,07),Price = 205,Volumn = 300,Amount = 61604}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,06,12),Price = 227,Volumn = 300,Amount = 68215}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,07,29),Price = 202,Volumn = 300,Amount = 60702}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,01,08),Price = 136.5,Volumn = 500,Amount = 68365},
                                SellOrder = new Order(){Date = new DateTime(2016,03,07),Price = 183,Volumn = 500,Amount = 91346}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,06,03),Price = 163.5,Volumn = 400,Amount = 65510},
                                SellOrder = new Order(){Date = new DateTime(2017,05,23),Price = 178,Volumn = 400,Amount = 71080.39}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "kce",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,07,19),Price = 8.8,Volumn = 1100,Amount = 9696},
                                SellOrder = new Order(){Date = new DateTime(2012,12,04),Price = 9.85,Volumn = 1100,Amount = 10818}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,09,15),Price = 8.1,Volumn = 1300,Amount = 10547},
                                SellOrder = new Order(){Date = new DateTime(2012,10,24),Price = 9.85,Volumn = 1300,Amount = 12752}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,12,07),Price = 7.3,Volumn = 1400,Amount = 10236},
                                SellOrder = new Order(){Date = new DateTime(2012,12,04),Price = 9.85,Volumn = 1400,Amount = 13740}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,06,24),Price = 7,Volumn = 6000,Amount = 42016},
                                SellOrder = new Order(){Date = new DateTime(2012,08,03),Price = 7.65,Volumn = 6000,Amount = 45822}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,09,15),Price = 5.75,Volumn = 7000,Amount = 40318},
                                SellOrder = new Order(){Date = new DateTime(2012,12,04),Price = 9.85,Volumn = 7000,Amount = 68839}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2011,10,13),Price = 3.84,Volumn = 10500,Amount = 40388},
                                SellOrder = new Order(){Date = new DateTime(2011,11,08),Price = 4.94,Volumn = 10500,Amount = 51787}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,03,01),Price = 97,Volumn = 800,Amount = 77730},
                                SellOrder = new Order(){Date = new DateTime(2017,04,04),Price = 103.5,Volumn = 800,Amount = 82661}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,09,01),Price = 87.75,Volumn = 800,Amount = 70318}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "smit",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,07,19),Price = 2.1,Volumn = 14500,Amount = 30499}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,08,19),Price = 2.14,Volumn = 4500,Amount = 9645}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2010,09,02),Price = 1.99,Volumn = 5000,Amount = 9966},
                                SellOrder = new Order(){Date = new DateTime(2010,09,17),Price = 2.02,Volumn = 5000,Amount = 10084}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,09,10),Price = 5.05,Volumn = 9200,Amount = 46538}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,09,05),Price = 4.52,Volumn = 15500,Amount = 70178},
                                SellOrder = new Order(){Date = new DateTime(2017,05,09),Price = 5.35,Volumn = 15500,Amount = 82785.68}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2016,05,09),Price = 3.86,Volumn = 18000,Amount = 69597},
                                SellOrder = new Order(){Date = new DateTime(2017,01,06),Price = 4.92,Volumn = 18000,Amount = 88411}
                            } 
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "kbank",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,05,18),Price = 206,Volumn = 300,Amount = 61904}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,07,09),Price = 182,Volumn = 400,Amount = 72923},
                                SellOrder = new Order(){Date = new DateTime(2017,09,01),Price = 202,Volumn = 400,Amount = 80664}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,12,11),Price = 155,Volumn = 400,Amount = 62105},
                                SellOrder = new Order(){Date = new DateTime(2016,03,07),Price = 182.5,Volumn = 400,Amount = 72877}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "mcs",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,10,11),Price = 6.4,Volumn = 8000,Amount = 51286}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,04,09),Price = 5.15,Volumn = 10000,Amount = 51587},
                                SellOrder = new Order(){Date = new DateTime(2016,11,10),Price = 17.2,Volumn = 10000,Amount = 171710}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,01,13),Price = 3.98,Volumn = 12000,Amount = 47841},
                                SellOrder = new Order(){Date = new DateTime(2014,02,25),Price = 4.68,Volumn = 12000,Amount = 56065}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,19),Price = 15.1,Volumn = 4600,Amount = 69576.67}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "delta",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,06,04),Price = 36.25,Volumn = 1400,Amount = 50836},
                                SellOrder = new Order(){Date = new DateTime(2017,05,25),Price = 92.5,Volumn = 1400,Amount = 129282.44}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "pttgc",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2007,12,28),Price = 90.77,Volumn = 1155,Amount = 105008}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2012,11,07),Price = 62.5,Volumn = 1000,Amount = 62606},
                                SellOrder = new Order(){Date = new DateTime(2013,05,10),Price = 76.5,Volumn = 1000,Amount = 76370}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,06,16),Price = 67.5,Volumn = 1000,Amount = 67614},
                                SellOrder = new Order(){Date = new DateTime(2017,04,05),Price = 72.5,Volumn = 1000,Amount = 72378}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,10,16),Price = 58,Volumn = 1200,Amount = 69718},
                                SellOrder = new Order(){Date = new DateTime(2015,06,19),Price = 69,Volumn = 1200,Amount = 82660}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2015,08,24),Price = 49.25,Volumn = 1400,Amount = 69066},
                                SellOrder = new Order(){Date = new DateTime(2016,03,06),Price = 58.75,Volumn = 1400,Amount = 82111}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "snc",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,02,04),Price = 25.25,Volumn = 2700,Amount = 68290}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,03,25),Price = 22.5,Volumn = 3000,Amount = 67614}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2013,10,14),Price = 19.8,Volumn = 2500,Amount = 49584}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2014,10,17),Price = 15.1,Volumn = 4600,Amount = 69577},
                                SellOrder = new Order(){Date = new DateTime(2014,03,29),Price = 16.8,Volumn = 4600,Amount = 77150}
                            },
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,29),Price = 15,Volumn = 4600,Amount = 69115.91}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "mfec",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,25),Price = 5.2,Volumn = 13000,Amount = 67713.57}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bla",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,05,30),Price = 45.75,Volumn = 1500,Amount = 68740.28}
                            }
                        }
                    },
                    new QuoteMovement()
                    {
                        Quote = "bdms",
                        Transaction = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                BuyOrder = new Order(){Date = new DateTime(2017,06,06),Price = 18.80,Volumn = 3700,Amount = 69676.85},
                                SellOrder = new Order(){Date = new DateTime(2017,09,01),Price = 20.9,Volumn = 3700,Amount = 77200}
                            }
                        }
                    }
                };
            }
        }
    }
}