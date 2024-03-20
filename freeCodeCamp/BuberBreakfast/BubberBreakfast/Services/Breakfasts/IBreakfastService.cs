using BubberBreakfast.Models;

namespace BubberBreakfast.Services.Breakfasts
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);

        void DeleteBreakfast(Guid id);

        Breakfast GetBreakfast(Guid id);

        void UpsertBreakfast(Breakfast breakfast);
    }
}
