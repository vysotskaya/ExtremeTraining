using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BLL.Interface.BllEntities;
using DAL.Interface.DalEntities;

namespace BLL.Mappers
{
    public static partial class BllDalMappers
    {
        public static UserEntity ToUserEntity(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Email = dalUser.Email,
                Password = dalUser.Password,
                Photo = dalUser.Photo.ByteArrayToImage()
               
            };
        }

        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Photo = userEntity.Photo.ImageToByteArray()
            };
        }

        public static Byte[] ImageToByteArray(this Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
            return null;
        }

        public static Image ByteArrayToImage(this Byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;
        }
    }
}
