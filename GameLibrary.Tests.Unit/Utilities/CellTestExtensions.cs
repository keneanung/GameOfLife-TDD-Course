using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using GameLibrary.Domain;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class CellTestExtensions
    {
        internal static CellAssertions Should(this Cell cell)
        {
            return new(cell);
        }

        internal class CellAssertions: ReferenceTypeAssertions<Cell, CellAssertions>
        {
            public CellAssertions(Cell cell)
            {
                Subject = cell;
            }

            protected override string Identifier => "cell";

            public AndConstraint<CellAssertions> BeAlive(string because = "", params object[] becauseArgs)
            {
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .ForCondition(Subject.Alive)
                    .FailWith("Expected {context:cell} to be alive but it isn't");

                return new AndConstraint<CellAssertions>(this);
            }

            public AndConstraint<CellAssertions> BeDead(string because = "", params object[] becauseArgs)
            {
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .ForCondition(!Subject.Alive)
                    .FailWith("Expected {context:cell} to be dead but it isn't");

                return new AndConstraint<CellAssertions>(this);
            }
        }
    }
}