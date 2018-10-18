using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TrainingProductViewModel
    {
        public List<TrainingProduct> Products;
        public string EventCommand { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            ValidationErrors = new List<KeyValuePair<string, string>>();

            EventCommand = "List";
            IsValid = true;
            ListMode();
        }

        public void Get()
        {
            var tpm = new TrainingProductManager();
            Products = tpm.Get(SearchEntity);
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
                case "add":
                    AddMode();
                    break;
                case "save":
                    Save();
                    break;
                case "cancel":
                    ListMode();
                    Get();
                    break;
                default:
                    break;
            }
        }

        private void ListMode()
        {
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            Mode = "List";
        }

        private void AddMode()
        {
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            Mode = "Add";
        }

        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct();
            Entity.IntrodutionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;
        }

        private void Save()
        {
            var mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else if (Mode == "Update")
            {

            }

            ValidationErrors = mgr.ValidationErrors;
            IsValid = !(ValidationErrors.Count > 0);

            if (!IsValid)
            {
                if (Mode == "Add")
                    AddMode();
            }

        }
    }
}
