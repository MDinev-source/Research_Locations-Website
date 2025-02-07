﻿namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Pictures;

    public interface IPicturesService
    {
        Task<IEnumerable<ObjectPictureViewModel>> GetAllPicturesAsync(string objectId);

        Task<IEnumerable<ObjectPictureViewModel>> GetAllDbPicturesAsync();

        Task DeleteAllPicuresFromCurrentobject(string districtViewObjectId);

        Task<PictureDeleteViewModel> GetDeleteViewModelByIdAsync(string id, string objectId);

        Task DeleteByIdAsync(string id);

        int GetIndex(string pictureId, string objectId);

        int GetIndexForAllPics(string pictureId);

        Picture GetPicture(string id);
    }
}
