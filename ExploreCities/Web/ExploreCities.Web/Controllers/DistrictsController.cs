﻿namespace ExploreCities.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.Districts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using X.PagedList;

    public class DistrictsController : Controller
    {
        private readonly IDistrictsService districtsService;
        private readonly ICitiesService citiesService;
        private readonly UserManager<ApplicationUser> userManager;

        public DistrictsController(
            IDistrictsService districtsService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager)
        {
            this.districtsService = districtsService;
            this.citiesService = citiesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All(ListDistrictsViewModel listDistrictsViewModel, string cityId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var districts = await this.districtsService.GetAllDistrictsAsync(listDistrictsViewModel.CityId ?? cityId, user.Id);

            if (listDistrictsViewModel.SearchString != null)
            {
                districts = this.districtsService.GetDistrictsFromSearch(listDistrictsViewModel.SearchString, listDistrictsViewModel.CityId).ToList();
            }

            districts = this.districtsService.SortBy(districts.ToArray(), listDistrictsViewModel.Sorter).ToList();

            var pageNumber = listDistrictsViewModel.PageNumber ?? 1;
            var pageSize = listDistrictsViewModel.PageSize ?? 6;
            var pageCitiesViewModel = districts.ToPagedList(pageNumber, pageSize);

            listDistrictsViewModel.AllDistricts = pageCitiesViewModel;

            listDistrictsViewModel.CityName = this.citiesService.GetCity(listDistrictsViewModel.CityId).Name;

            return this.View(listDistrictsViewModel);
        }

        public async Task<IActionResult> Rate(string districtId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.districtsService.RateDistrict(districtId, user.Id);

            var cityId = this.districtsService.GetDistrict(districtId).CityId;

            return this.RedirectToAction(nameof(this.All), new { cityId });
        }
    }
}
