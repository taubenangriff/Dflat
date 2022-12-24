using Dflat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GeneralizedIntervalSystems
{
    public interface IGeneralizedIntervalSystem<TElement, TInterval>
        where TElement : IElement
        where TInterval : IInterval
    {
        IBuilder<TInterval> GetIntervalAsBuilder(TElement e1, TElement e2);
        IBuilder<TElement> ApplyIntervalForBuilder(TElement element, TInterval interval);

        Type IntervalType => typeof(TInterval);
        Type ElementType => typeof(TElement);
    }

    public static class IGeneralizedIntervalSystemExtensions
    {
        public static TInterval? GetInterval<TElement, TInterval>(this IGeneralizedIntervalSystem<TElement, TInterval> system, TElement e1, TElement e2)
            where TElement : IElement
            where TInterval : IInterval
        {
            return system.GetIntervalAsBuilder(e1, e2).Build();
        }

        public static TElement? ApplyInterval<TElement, TInterval>(this IGeneralizedIntervalSystem<TElement, TInterval> system, TElement element, TInterval interval)
            where TElement : IElement
            where TInterval : IInterval
        {
            return system.ApplyIntervalForBuilder(element, interval).Build();
        }
    }
}
