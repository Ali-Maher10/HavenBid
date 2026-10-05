using Microsoft.EntityFrameworkCore;
public interface IHouseRepository
{
    Task<List<HouseDto>> GetAll();
    Task<HouseDetailDto?> Get(int id);
    Task<HouseDetailDto> Add(HouseDetailDto dto);
    Task<HouseDetailDto> Update(HouseDetailDto dto);
    Task Delete(int id);
}
public class HouseRepository: IHouseRepository  
{
    private readonly HouseDbContext _dbContext;

    public HouseRepository(HouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static void DtoToEntity(HouseDetailDto dto,HouseEntity entity)
    {
        entity.Address = dto.Address;
        entity.Country = dto.Country;
        entity.Price = dto.Price;
        entity.Description = dto.Description;
        entity.Photo = dto.Photo;
    }

     private static HouseDetailDto EntityToDetailDto(HouseEntity entity)
     {
         return new HouseDetailDto(entity.Id, entity.Address, entity.Country, entity.Price, entity.Description, entity.Photo);
     }
    public async Task<List<HouseDto>> GetAll()
    {
        return await _dbContext.Houses.Select(h => new HouseDto(h.Id, h.Address, h.Country, h.Price, h.Photo)).ToListAsync();
    }
    public async Task<HouseDetailDto?> Get(int id)
    {
        var e = await _dbContext.Houses.SingleOrDefaultAsync(
            h => h.Id == id);
            if(e == null)
                return null;
            return EntityToDetailDto(e);
    }
    public async Task<HouseDetailDto> Add(HouseDetailDto dto)
    {
        var entity = new HouseEntity();
        DtoToEntity(dto, entity);

        _dbContext.Houses.Add(entity);
        await _dbContext.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }

        public async Task<HouseDetailDto> Update(HouseDetailDto dto)
    {
        var entity = await _dbContext.Houses.FindAsync(dto.Id);
        if (entity ==null)
            throw new ArgumentException($"Error updating house:{dto.Id}.");

        DtoToEntity(dto, entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }

            public async Task Delete(int id )
    {
        var entity = await _dbContext.Houses.FindAsync(id);
        if (entity ==null)
            throw new ArgumentException($"Error deleting house:{id}.");

        _dbContext.Houses.Remove(entity);
        await _dbContext.SaveChangesAsync();
        
    }
}