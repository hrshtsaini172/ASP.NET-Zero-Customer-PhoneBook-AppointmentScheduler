using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetZeroCore.Net;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTraining1121AngularDemo.Authorization.Users.Profile;
using MyTraining1121AngularDemo.Authorization.Users.Profile.Dto;
using MyTraining1121AngularDemo.Dto;
using MyTraining1121AngularDemo.Storage;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace MyTraining1121AngularDemo.Web.Controllers
{
    public abstract class ProfileControllerBase : MyTraining1121AngularDemoControllerBase
    {
        private readonly ITempFileCacheManager _tempFileCacheManager;
        private readonly IProfileAppService _profileAppService;

        private const int MaxProfilePictureSize = 5242880; //5MB

        protected ProfileControllerBase(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService)
        {
            _tempFileCacheManager = tempFileCacheManager;
            _profileAppService = profileAppService;
        }

        public UploadProfilePictureOutput UploadProfilePicture(FileDto input)
        {
            try
            {
                var profilePictureFile = Request.Form.Files.First();

                //Check input
                if (profilePictureFile == null)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
                }

                if (profilePictureFile.Length > MaxProfilePictureSize)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit",
                        AppConsts.MaxProfilePictureBytesUserFriendlyValue));
                }

                byte[] fileBytes;
                using (var stream = profilePictureFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                using (var image = Image.Load(fileBytes, out IImageFormat format))
                {
                    if (!format.IsIn(JpegFormat.Instance, PngFormat.Instance, GifFormat.Instance))
                    {
                        throw new UserFriendlyException(L("IncorrectImageFormat"));
                    }

                    _tempFileCacheManager.SetFile(input.FileToken, fileBytes);

                    return new UploadProfilePictureOutput
                    {
                        FileToken = input.FileToken,
                        FileName = input.FileName,
                        FileType = input.FileType,
                        Width = image.Width,
                        Height = image.Height
                    };
                }
            }
            catch (UserFriendlyException ex)
            {
                return new UploadProfilePictureOutput(new ErrorInfo(ex.Message));
            }
        }

        [AllowAnonymous]
        public FileResult GetDefaultProfilePicture()
        {
            return GetDefaultProfilePictureInternal();
        }

        public async Task<FileResult> GetProfilePictureByUser(long userId)
        {
            var output = await _profileAppService.GetProfilePictureByUser(userId);
            if (output.ProfilePicture.IsNullOrEmpty())
            {
                return GetDefaultProfilePictureInternal();
            }

            return File(Convert.FromBase64String(output.ProfilePicture), MimeTypeNames.ImageJpeg);
        }

        protected FileResult GetDefaultProfilePictureInternal()
        {
            return File(Path.Combine("Common", "Images", "default-profile-picture.png"), MimeTypeNames.ImagePng);
        }
    }
}