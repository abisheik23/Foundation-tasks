using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restfulapi.Models;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using Restfulapi.Utils;
namespace Restfulapi.Controllers
{
    public class CarsController : ApiController
    {
        public static List<Cars> _cars = new List<Cars>() { 
            new Cars() 
        { id = 1, name = "Honda Civic", description = "Luxury Model 2013" }, 
        new Cars() { id = 2, name = "Honda Accord", description = "Deluxe Model 2012" }, new Cars() 
        { id = 3, name = "BMW V6", description = "V6 Engine Luxury 2013" }, new Cars() 
        { id = 4, name = "Audi A8", description = "V8 Engine 2013" }, 
        new Cars() { id = 5, name = "Mercedes M3", description = "Basic Model 2013" } 
        };
        // GET cars
        /// <summary>
        ///     Shows the list of cars
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not Found Error</response>
        /// <description>
        /// This function provides all the data available in the list
        /// </description>
        /// <remarks>
        ///  This is used to show the list of cars     
        ///     
        ///</remarks>
        [Route("cars")]
       // [SwaggerOperation(Tags = new[] { "" })]
        [ResponseType(typeof(ResponseWrapper<Cars>))]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return _cars.GetHttpResponseInstance();
        }

        // GET cars/5
        // GET cars
        /// <summary>
        ///  shows the car using its id number   
        /// </summary>
        /// <param name="id">Get/Set Id</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not Found Error</response>
        /// <description>
        /// This function shows the data where the id is equal to the data in the list 
        /// </description>
        /// <remarks>
        ///  This is used to show the list of cars by its id   
        ///     
        /// </remarks>
        [Route("cars/{id}")]
        [ResponseType(typeof(ResponseWrapper<Cars>))]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Cars car = _cars.Find(c => c.id == id);
                if (car == null)
                {

                    return new HttpResponseMessage(HttpStatusCode.NotFound);

                }
                else
                    return car.GetHttpResponseInstance();
            
            
        }

        
        /// <summary>
        ///     This is used to create data for cars
        /// </summary>
        /// <param name="c"> Get/Set object </param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not Found Error</response>
        /// <description>
        /// This function is used to create data and add in the list of cars
        /// </description>
        /// <remarks>
        ///  This is used to create data for cars    
        ///     
        /// </remarks>
        [Route("cars")]
        [HttpPost]
        [ResponseType(typeof(ResponseWrapper<Cars>))]
        public HttpResponseMessage Post(Cars c)
        {
            if (c == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                _cars.Add(c);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

        }

        
        /// <summary>
        ///     This is used to Update the list of cars
        /// </summary>
        /// <param name="id">Get/Set id</param>
        /// <param name="p">Get/Set object</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not Found Error</response>
        /// <decription>
        /// This function is used Update the list of cars by its id number
        /// </decription>
        /// <remarks>
        ///   This is used to update the list of cars  
        ///     
        /// </remarks>
        [Route("cars/{id}")]
        [ResponseType(typeof(ResponseWrapper<Cars>))]
        [HttpPut]
        public HttpResponseMessage Put(int id,Cars p)
        {
            try
            {
                Cars pro = _cars.Find(pr => pr.id == id);
                pro.id = p.id;
                pro.name = p.name;
                pro.description = p.description;

                return pro.GetHttpResponseInstance();
            }

            catch (Exception) {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

               
            
            
        }

        // DELETE cars/5
        // GET cars
        /// <summary>
        ///     This is used to delete the cars in the list
        /// </summary>
        /// <param name="id">Get/Set id</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not Found Error</response>
        /// <description>
        /// This function is used to delete the cars by its id which
        /// is present in the list
        /// </description>
        /// <remarks>
        /// This is used to delete the cars in the list    
        ///     
        /// </remarks>
        [Route("cars/{id}")]
        [ResponseType(typeof(ResponseWrapper<Cars>))]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Cars Car = _cars.Find(c => c.id == id);
            if (Car == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                _cars.Remove(Car);
                return _cars.GetHttpResponseInstance();
            }

        }
    }
}
