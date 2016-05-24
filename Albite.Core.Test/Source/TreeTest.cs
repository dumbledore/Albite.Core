using Albite.Collections;
using Albite.Diagnostics;
using System.Collections.Generic;

namespace Albite.Test
{
    public class TreeTest
    {
        private static readonly string[] Expected =
        {
            "1",
            "1.1",
            "1.2",
            "2",
            "2.1",
            "2.1.1",
            "2.1.2",
            "3",
            "3.1",
        };

        private void AssertTree(ITree<string> tree)
        {
            // Convert ITree<> to a List<>
            List<string> actual = new List<string>();
            foreach (INode<string> node in tree)
            {
                Logger.LogMessage("{0}", node.Value);
                actual.Add(node.Value);
            }

            CollectionAssert.AreEqual(Expected, actual);
        }

        private class StaticNode : INode<string>
        {
            public INode<string> FirstChild { get; private set; }
            public INode<string> NextSibling { get; private set; }
            public string Value { get; private set; }

            public StaticNode(StaticNode firstChild, StaticNode nextSibling, string value)
            {
                FirstChild = firstChild;
                NextSibling = nextSibling;
                Value = value;
            }

            public StaticNode(string value) : this(null, null, value) { }
        }

        private ITree<string> CreateStaticTree()
        {
            return new Tree<string>(
                new StaticNode(                                   // Root (1)
                    new StaticNode(                               // Root's child (1.1)
                        null,
                        new StaticNode("1.2"),                    // Root's child's sibling (1.2)
                        "1.1"),
                    new StaticNode(                               // Root's sibling (2)
                        new StaticNode(                           // Root's sibling's child (2.1)
                            new StaticNode(                       // Root's sibling's child's child (2.1.1)
                                null,
                                new StaticNode("2.1.2"),          // Root's sibling's child's sibling (2.1.2)
                                "2.1.1"),
                            null,
                            "2.1"),
                        new StaticNode(                           // Root's sibling's sibling (3)
                            new StaticNode("3.1"),                // Root's sibling's sibling's child (3.1)
                            null,
                            "3"),
                    "2"),
                "1")
            );
        }

        public void StaticTreeTest()
        {
            AssertTree(CreateStaticTree());
        }
    }
}
