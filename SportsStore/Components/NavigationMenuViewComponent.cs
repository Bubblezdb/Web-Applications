using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.Components
{
    /*view components are perfect for creating items such as reusable navigation controls
     * view component is a C# class that provides a small amount of reusable application logic
     * with the ability to select and display Razor partial views.
     */
    public class NavigationMenuViewComponent :ViewComponent
    {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo) => repository = repo; //dependency injection
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            /*view bags allows unstructured data to be
             * passed to a view alongside the view model
               object.*/
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
        /*Invoke method is called when the component is used in a Razor view, 
         * and the result of the Invoke method is inserted into the HTML sent to the browser.
         */
    }
}
