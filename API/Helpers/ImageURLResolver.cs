using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;
public class ImageURLResolver : IValueResolver<Product, ProductDto, string>
{
    private readonly IConfiguration _configuration;

    public ImageURLResolver(IConfiguration configuration )
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductDto destination, string destMember
    , ResolutionContext context)
    {
        if(!string.IsNullOrEmpty(source.PictureURL))
        {
            return _configuration["apiUrl"]+source.PictureURL;
        }
        return null;
    }
}
