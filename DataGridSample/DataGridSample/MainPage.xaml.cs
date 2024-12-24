using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class OrderInfo : INotifyPropertyChanged
    {
        private int orderID;
        private string? firstname;
        private string? lastname;
        private string? gender;
        private string? shipCity;
        private string? shipCountry;
        private double freight;
        private DateTime shippingDate;
        private bool isClosed;
        private double price;

        public OrderInfo()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public int OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public string? FirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string? LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string? Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
                RaisePropertyChanged("Gender");
            }
        }

        public string? City
        {
            get
            {
                return shipCity;
            }

            set
            {
                shipCity = value;
                RaisePropertyChanged("City");
            }
        }

        public string? Country
        {
            get
            {
                return shipCountry;
            }

            set
            {
                shipCountry = value;
                RaisePropertyChanged("Country");
            }
        }

        public double Freight
        {
            get
            {
                return freight;
            }

            set
            {
                freight = value;
                RaisePropertyChanged("Freight");
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public bool IsClosed
        {
            get
            {
                return isClosed;
            }

            set
            {
                isClosed = value;
                RaisePropertyChanged("IsClosed");
            }
        }

        public DateTime Date
        {
            get
            {
                return shippingDate;
            }

            set
            {
                shippingDate = value;
                RaisePropertyChanged("Date");
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class OrderInfoViewModel : INotifyPropertyChanged
    {
        private List<DateTime>? orderedDates;
        private Random random = new Random();
        private ObservableCollection<OrderInfo>? ordersInfo;

        private string[] genders = new string[]
        {
        "Male",
        "Female",
        "Female",
        "Female",
        "Male",
        "Male",
        "Male",
        "Male",
        "Male",
        "Male",
        "Male",
        "Male",
        "Female",
        "Female",
        "Female",
        "Male",
        "Male",
        "Male",
        "Female",
        "Female",
        "Female",
        "Male",
        "Male",
        "Male",
        "Male"
        };

        private string[] firstNames = new string[]
        {
        "Kyle",
        "Gina",
        "Irene",
        "Katie",
        "Michael",
        "Oscar",
        "Ralph",
        "Torrey",
        "William",
        "Bill",
        "Daniel",
        "Frank",
        "Brenda",
        "Danielle",
        "Fiona",
        "Howard",
        "Jack",
        "Larry",
        "Holly",
        "Jennifer",
        "Liz",
        "Pete",
        "Steve",
        "Vince",
        "Zeke",
         "Gary",
        "Maciej",
        "Shelley",
        "Linda",
        "Carla",
        "Carol",
        "Shannon",
        "Jauna",
        "Michael",
        "Terry",
        "John",
        "Gail",
        "Mark",
        "Martha",
        "Julie",
        "Janeth",
        "Twanna",
        "Frank",
        "Crowley",
        "Waddell",
        "Irvine",
        "Keefe",
        "Ellis",
        "Gable",
        "Mendoza",
        "Rooney",
        "Lane",
        "Landry",
        "Perry",
        "Perez",
        "Newberry",
        "Betts",
        "Fitzgerald",
        "Adams",
        "Owens",
        "Thomas",
        "Doran",
        "Jefferson",
        "Spencer",
        "Vargas",
        "Grimes",
        "Edwards",
        "Stark",
        "Cruise",
        "Fitz",
        "Chief",
        "Blanc",
        "Stone",
        "Williams",
        "Jobs",
        "Holmes"
        };

        private string[] lastNames = new string[]
        {
        "Adams",
        "Crowley",
        "Ellis",
        "Gable",
        "Irvine",
        "Keefe",
        "Mendoza",
        "Owens",
        "Rooney",
        "Waddell",
        "Thomas",
        "Betts",
        "Doran",
        "Holmes",
        "Jefferson",
        "Landry",
        "Newberry",
        "Perez",
        "Spencer",
        "Vargas",
        "Grimes",
        "Edwards",
        "Stark",
        "Cruise",
        "Fitz",
        "Chief",
        "Blanc",
        "Perry",
        "Stone",
        "Williams",
        "Lane",
        "Jobs"
        };

        private string[] shipCountry = new string[]
        {
        "Argentina",
        "Austria",
        "Belgium",
        "Brazil",
        "Canada",
        "Denmark",
        "Finland",
        "France",
        "Germany",
        "Ireland",
        "Italy",
        "Mexico",
        "Norway",
        "Poland",
        "Portugal",
        "Spain",
        "Sweden",
        "UK",
        "USA",
        };

        public event PropertyChangedEventHandler? PropertyChanged;

        private Dictionary<string, string[]> shipCity = new Dictionary<string, string[]>();

        public OrderInfoViewModel()
        {
            OrdersInfo = GetOrderDetails(100);
        }

        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            SetShipCity();
            orderedDates = GetDate(2010, 2024, count);
            ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo>();
            int index = 0;
            for (int i = 10001; i <= count + 10000; i++)
            {
                index = index + 1;
                var shipcountry = shipCountry[random.Next(5)];
                var shipcity = shipCity[shipcountry];

                var order = new OrderInfo()
                {
                    OrderID = i,
                    FirstName = index > 72 ? firstNames[random.Next(40)] : firstNames[index],
                    LastName = lastNames[random.Next(15)],
                    Gender = genders[random.Next(5)],
                    Country = shipcountry,
                    Date = orderedDates[i - 10001],
                    Freight = Math.Round(random.Next(1000) + random.NextDouble(), 2),
                    Price = Math.Round(random.Next(1000) + random.NextDouble(), 3),
                    IsClosed = (i % random.Next(1, 10) > 2) ? true : false,
                    City = shipcity[random.Next(shipcity.Length - 1)],
                };
                orderDetails.Add(order);
            }

            return orderDetails;
        }

        public ObservableCollection<OrderInfo>? OrdersInfo
        {
            get
            {
                return this.ordersInfo;
            }

            set
            {
                this.ordersInfo = value;
                this.RaisePropertyChanged("OrdersInfo");
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private List<DateTime> GetDate(int startYear, int endYear, int count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }

            return date;
        }

        private void SetShipCity()
        {
            string[] argentina = new string[]
            {
            "Rosario"
            };

            string[] austria = new string[]
            {
            "Graz",
            "Salzburg"
            };

            string[] belgium = new string[]
            {
            "Bruxelles",
            "Charleroi"
            };

            string[] brazil = new string[]
            {
            "Campinas",
            "Resende",
            "Recife",
            "Manaus"
            };

            string[] canada = new string[]
            {
            "Montréal",
            "Tsawassen",
            "Vancouver"
            };

            string[] denmark = new string[]
            {
            "Århus",
            "København"
            };

            string[] finland = new string[]
            {
            "Helsinki",
            "Oulu"
            };

            string[] france = new string[]
            {
            "Lille",
            "Lyon",
            "Marseille",
            "Nantes",
            "Paris",
            "Reims",
            "Strasbourg",
            "Toulouse",
            "Versailles"
            };

            string[] germany = new string[]
            {
            "Aachen",
            "Berlin",
            "Brandenburg",
            "Cunewalde",
            "Frankfurt",
            "Köln",
            "Leipzig",
            "Mannheim",
            "München",
            "Münster",
            "Stuttgart"
            };

            string[] ireland = new string[]
            {
            "Cork"
            };

            string[] italy = new string[]
            {
            "Bergamo",
            "Reggio",
            "Torino"
            };

            string[] mexico = new string[]
            {
            "México D.F."
            };

            string[] norway = new string[]
            {
            "Stavern"
            };

            string[] poland = new string[]
            {
            "Warszawa"
            };

            string[] portugal = new string[]
            {
            "Lisboa"
            };

            string[] spain = new string[]
            {
            "Barcelona",
            "Madrid",
            "Sevilla"
            };

            string[] sweden = new string[]
            {
            "Bräcke",
            "Luleå"
            };

            string[] switzerland = new string[]
            {
            "Bern",
            "Genève"
            };

            string[] uk = new string[]
            {
            "Colchester",
            "Hedge End",
            "London"
            };

            string[] usa = new string[]
            {
            "Albuquerque",
            "Anchorage",
            "Boise",
            "Butte",
            "Elgin",
            "Eugene",
            "Kirkland",
            "Lander",
            "Portland",
            "San Francisco",
            "Seattle",
            };

            string[] venezuela = new string[]
            {
            "Barquisimeto",
            "Caracas", "I. de Margarita",
            "San Cristóbal"
            };

            if (shipCity.Count == 0)
            {
                shipCity.Add("Argentina", argentina);
                shipCity.Add("Austria", austria);
                shipCity.Add("Belgium", belgium);
                shipCity.Add("Brazil", brazil);
                shipCity.Add("Canada", canada);
                shipCity.Add("Denmark", denmark);
                shipCity.Add("Finland", finland);
                shipCity.Add("France", france);
                shipCity.Add("Germany", germany);
                shipCity.Add("Ireland", ireland);
                shipCity.Add("Italy", italy);
                shipCity.Add("Mexico", mexico);
                shipCity.Add("Norway", norway);
                shipCity.Add("Poland", poland);
                shipCity.Add("Portugal", portugal);
                shipCity.Add("Spain", spain);
                shipCity.Add("Sweden", sweden);
                shipCity.Add("Switzerland", switzerland);
                shipCity.Add("UK", uk);
                shipCity.Add("USA", usa);
                shipCity.Add("Venezuela", venezuela);
            }
        }
    }
}
