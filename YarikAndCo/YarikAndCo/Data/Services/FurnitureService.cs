using Microsoft.EntityFrameworkCore;

public class FurnitureService
{

    private FurnitureStoreContext _context;
    public FurnitureService(FurnitureStoreContext context)
    {
        _context = context;
    }

    public async Task<Furniture?> AddFurniture(Furniture furniture)
    {
        Furniture nfurniture = new Furniture
        {
            furnitureName = furniture.furnitureName,
            roomType = furniture.roomType,
            type = furniture.type,
            price = furniture.price,
            oldPrice = furniture.oldPrice,
            imageLink1 = furniture.imageLink1,
            imageLink2 = furniture.imageLink2,
            imageLink3 = furniture.imageLink3,
            imageLink4 = furniture.imageLink4,
            aboutText = furniture.aboutText

        };

        var result = _context.Furnitures.Add(nfurniture);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<Furniture?> GetFurniture(int id)
    {

        var result = _context.Furnitures.Include(fur => fur.orders).FirstOrDefault(furniture => furniture.id == id);

        return await Task.FromResult(result);
    }

    public async Task<List<Furniture>> GetFurnitures()
    {
        var result = await _context.Furnitures.Include(fur => fur.orders).ToListAsync();
        return await Task.FromResult(result);
    }

    public async Task<Furniture?> UpdateFurniture(int id, Furniture newFurniture)
    {
        var furniture = await _context.Furnitures.FirstOrDefaultAsync(fu => fu.id == id);
        if (furniture != null)
        {
            furniture.furnitureName = newFurniture.furnitureName;
            furniture.type = newFurniture.type;
            furniture.roomType = newFurniture.roomType;
            furniture.price = newFurniture.price;
            furniture.oldPrice = newFurniture.oldPrice;
            furniture.imageLink1 = newFurniture.imageLink1;
            furniture.imageLink2 = newFurniture.imageLink2;
            furniture.imageLink3 = newFurniture.imageLink3;
            furniture.imageLink4 = newFurniture.imageLink4;
            furniture.aboutText = newFurniture.aboutText;

            _context.Furnitures.Update(furniture);
            _context.Entry(furniture).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return furniture;
        }

        return null;
    }

    public async Task<bool> DeleteFurniture(int id)
    {
        var furniture = await _context.Furnitures.FirstOrDefaultAsync(fu => fu.id == id);
        if (furniture != null)
        {
            _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }


}

