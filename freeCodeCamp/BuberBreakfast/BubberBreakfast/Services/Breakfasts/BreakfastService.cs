using BubberBreakfast.Models;

namespace BubberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new ();

        public void CreateBreakfast(Breakfast breakfast)
        => _breakfasts.Add(breakfast.Id, breakfast);

        public void DeleteBreakfast(Guid id)
        => _breakfasts.Remove(id);

        public Breakfast GetBreakfast(Guid id)
        => _breakfasts[id];

        public void UpsertBreakfast(Breakfast breakfast)
        => _breakfasts[breakfast.Id] = breakfast;
    }
}
