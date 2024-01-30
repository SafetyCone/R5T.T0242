using System;

using R5T.T0142;
using R5T.T0243;


namespace R5T.T0242
{
    /// <summary>
    /// Test fixtures perform test on test article instances.
    /// </summary>
    /// <remarks>
    /// This is the first piece of a general testing framework methodology that works for both:
    /// 1. Functionality instance methods, and
    /// 2. Service definitions.
    /// The actual test methods should be defined in an inherited, abstract type XTestFixture that is still generic in the test article type,
    /// but that adds a restriction to the test article type in that it should implement an interface IXTestArticle.
    /// The XTestFixture is not marked as a TestClass, but does contain methods marked as TestMethods.
    /// This XTestFixture/IXTestArticle coevolve together.
    /// The library implementing the XTestFixture able to import lots value instances, especially expectations, and is very "heavy".
    /// The IXTestArticle interface is simpler, and can go into a T## sub-library that is very "light".
    /// This is the second piece of the general testing framework methodology.
    /// The third and final piece is a library that implements an XTestFixture_ForY class that is a concrete (non-abstract) derivation from the abstract XTestFixture type,
    /// and an XTestArticle_ForY class that implements the IXTestArticle interface.
    /// The XTestFixture_ForY class specifies the XTestArticle_ForY class as its type parameter,
    /// and the XTestArticle_ForY class implements the IXTestArticle interface by calling either:
    /// 1. Functionality instance methods to test them, or
    /// 2. Service definition methods for a service definition.
    /// Note that for service definitions, those have their own test fixture framework methodology.
    /// However, the general framework test fixture can be re-used by implementing a service-definition specific test article,
    /// which in turn serves as the test fixture for some service-implementation.
    /// </remarks>
    // Apply the test fixture marker attribute!
    [TestFixtureMarker, UtilityTypeMarker]
    public abstract class TestFixtureBase<TTestArticle>
    {
        /// <summary>
        /// Allows inheritors to provide a test article instance.
        /// This instance may or may not have been used in previous tests, it is left ambiguous.
        /// This detail is left up to the eventual test fixture implementation.
        /// </summary>
        public abstract TTestArticle TestArticle { get; }
    }
}
