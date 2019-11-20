using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper_
{
    public static class MapperExtension
    {
        public static TDestination Map<TDestination>(this object source)
        {
            return default(TDestination);
        }
    }

    public class Mapper<TSource, TDestination>
    {
        //public TDestination Map(TSource source)
        //{
        //    return default(TDestination);
        //}

        public TDestination Map(TSource userVm)
        {
            TDestination destination = Activator.CreateInstance<TDestination>();
            Type newUserEdited = destination.GetType();
            var newUserProperties = newUserEdited.GetProperties();

            Type userVmType = userVm.GetType();

            var userVmProperties = userVmType.GetProperties();

            foreach (var UserProperty in newUserProperties)
            {
                foreach (var UserVmProperty in userVmProperties)
                {
                    if (UserProperty.PropertyType == UserVmProperty.PropertyType
                        && UserProperty.Name == UserVmProperty.Name)
                    {
                        var VmPropertyValue = UserVmProperty.GetValue(userVm);
                        UserProperty.SetValue(destination, VmPropertyValue);
                    }
                }
            }

            return destination;
        }
    }
}
