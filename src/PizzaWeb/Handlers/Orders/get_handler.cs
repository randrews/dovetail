using FubuMVC.Core.SessionState;
using FubuMVC.WebForms;
using PizzaWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWeb.Handlers.Orders
{
    public class get_handler
    {
        private IRepository _repository;

        public get_handler(IRepository repository, IFlash flash)
        {
            _repository = repository;
        }

        public IEnumerable<PickupOrder> Execute()
        {
            return _repository.GetAll<PickupOrder>();
        }
    }

    public class OrdersView : FubuPage<IEnumerable<PickupOrder>> { }
}