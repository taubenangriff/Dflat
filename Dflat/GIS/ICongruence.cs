using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GIS
{
    /// <summary>
    /// An Abstraction to implement a Congruence between <typeparamref name="TInterval"/> and <typeparamref name="TResultInterval"/>.
    /// For the sake of optimization, the induced Equivalence Relation between <typeparamref name="TElement"/> and <typeparamref name="TResultElement"/> is implemented seperately.
    /// 
    /// The Programmer is responsible that an implementation indeed implements said Congruence and Equivalence Relation correctly. 
    /// </summary>
    /// <typeparam name="TInterval"></typeparam>
    /// <typeparam name="TResultInterval"></typeparam>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TResultElement"></typeparam>
    public interface ICongruence<TInterval, TResultInterval, TElement, TResultElement>
    {
        TResultInterval GetCongruent(TInterval interval);
        TInterval GetCongruentInverse(TResultInterval interval);

        TResultElement GetEquivalenceClass(TElement element);
        TElement GetEquivalenceClassElement(TResultElement element);
    }
}
