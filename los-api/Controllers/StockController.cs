using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace los_api.Controllers
{
    public class StockController : ApiController
    {
        //public HttpResponseMessage Get2(int productId)
        //{
        //    using (var context = new TestEntities())
        //    {
        //        var query = (from s in context.Stock
        //                     where s.productId == productId
        //                     select s
        //                     ).FirstOrDefault();

        //        if (query != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, query);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Stock Not Found");
        //        }
        //    }
        //}
        public HttpResponseMessage Get(int productId)
        {
            using (var context = new TestEntities())
            {
                Product query;
                if (productId != null)
                {
                     query = (from p in context.Product
                                 join s in context.Stock on p.id equals s.productId
                                 where s.amount > 0 && p.id == productId
                              select p
                                  ).FirstOrDefault();
                }
                else
                {
                     query = (from p in context.Product
                                 join s in context.Stock on p.id equals s.productId
                                 where s.amount > 0
                                 select p
                                  ).FirstOrDefault();
                }

                if (query != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, query);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Stock Not Found");
                }
            }
        }
    }
}
