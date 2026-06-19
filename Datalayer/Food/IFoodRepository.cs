namespace Datalayer.Food;

public interface IFoodRepository
{
    List<DbFood> GetFoods();
}