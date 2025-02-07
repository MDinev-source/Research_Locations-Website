﻿namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictViewsDetailsViewModel : IHaveCustomMappings, IMapFrom<DistrictView>
    {
        public string Id { get; set; }

        [Display(Name = "City name")]
        public string CityName { get; set; }

        [Display(Name = "District name")]
        public string DistrictName { get; set; }

        [Display(Name = "Arrival year")]
        public int ArrivalYear { get; set; }

        [Display(Name = "Departure year")]
        public int? DepartureYear { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Picture URL")]
        public string PictureUrl { get; set; }

        [Display(Name = "True")]
        public int Likes { get; set; }

        [Display(Name = "False")]
        public int Dislikes { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Parking spaces")]
        public ParkingSpacesExistence ParkingSpacesExistence { get; set; }

        [Display(Name = "Playgrounds")]
        public ChildrenPlaygroundsExistence ChildrenPlaygroundsExistence { get; set; }

        [Display(Name = "Air pollution")]
        public AirPollutionRating AirPollutionRating { get; set; }

        [Display(Name = "Noise")]
        public NoiseRating NoiseRating { get; set; }

        [Display(Name = "Public transport")]
        public PublicTransportRating PublicTransportRating { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictView, DistrictViewsViewModel>()
               .ForMember(vm => vm.DistrictName, o => o.MapFrom(x => x.District.Name))
               .ForMember(vm => vm.UserId, o => o.MapFrom(x => x.AddedByUserId));
        }
    }
}
