using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TrainingProductManager
    {
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if (!String.IsNullOrEmpty(entity.ProductName))
            {
                if(entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "ProductName must not be all lower case"));
                }
            }
            return ValidationErrors.Count == 0; 
        }

        public bool Insert(TrainingProduct entity)
        {
            var ret = false;
            ret = Validate(entity);
            if (ret)
            {
                //insert db
            }
            return ret;
        }

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            var rtv = CreateMockData();
            if(!String.IsNullOrEmpty(entity.ProductName))
            {
                rtv = rtv.FindAll(i => i.ProductName.Contains(entity.ProductName));
            }
            return rtv;
        }

        public List<TrainingProduct> CreateMockData()
        {
            var result = new List<TrainingProduct>();
            result.Add(new TrainingProduct { ProductName = "Product Name 1", IntrodutionDate = Convert.ToDateTime("2/22/2015"), Url = "http://sample.com", Price = 32 });
            result.Add(new TrainingProduct { ProductName = "Product Name 2", IntrodutionDate = Convert.ToDateTime("2/22/2016"), Url = "http://sample.com", Price = 36 });
            result.Add(new TrainingProduct { ProductName = "Product Name 3", IntrodutionDate = Convert.ToDateTime("2/22/2017"), Url = "http://sample.com", Price = 35 });
            result.Add(new TrainingProduct { ProductName = "Product Name 4", IntrodutionDate = Convert.ToDateTime("2/22/2018"), Url = "http://sample.com", Price = 35 });
            result.Add(new TrainingProduct { ProductName = "Product Name 5", IntrodutionDate = Convert.ToDateTime("2/23/2018"), Url = "http://sample.com", Price = 32 });
            result.Add(new TrainingProduct { ProductName = "Product Name 6", IntrodutionDate = Convert.ToDateTime("2/24/2018"), Url = "http://sample.com", Price = 31 });
            result.Add(new TrainingProduct { ProductName = "Product Name 7", IntrodutionDate = Convert.ToDateTime("2/25/2018"), Url = "http://sample.com", Price = 10 });
            result.Add(new TrainingProduct { ProductName = "Product Name 8", IntrodutionDate = Convert.ToDateTime("2/26/2018"), Url = "http://sample.com", Price = 20 });
            result.Add(new TrainingProduct { ProductName = "Product Name 9", IntrodutionDate = Convert.ToDateTime("2/27/2018"), Url = "http://sample.com", Price = 40 });
            return result;
        }
    }
}
