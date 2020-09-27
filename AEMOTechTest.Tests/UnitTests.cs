using Microsoft.VisualStudio.TestTools.UnitTesting;
using AEMOTechTest.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace AEMOTechTest.Tests
{
    [TestClass]
    public sealed class UnitTests
    {
        const string baconIpsum = "Spicy jalapeno bacon ipsum dolor amet pariatur fatback bacon, dolor ut prosciutto irure. Pastrami voluptate andouille, enim laboris filet mignon excepteur officia duis aute minim nisi fatback turducken. Beef ribs pancetta cupidatat, turkey spare ribs shoulder hamburger t-bone ribeye voluptate ut chuck. Bresaola excepteur veniam ipsum ullamco eu ex. Strip steak drumstick in, chuck adipisicing est qui salami pork dolor. Consectetur hamburger tenderloin turducken, id magna ball tip alcatra pig.";
        const string kiwiIpsum = "Kia ora.. Take a squiz, this snarky is as good as as a rip-off tiki tour. Meanwhile, in Hamilton, Tama and James Cook were up to no good with a bunch of sweet as L&Ps. The choice force of his playing rugby was on par with Fred Dagg's pretty suss whanau. Put the jug on will you bro, all these chocka full Tuis can wait till later. The first prize for skiving off goes to... a Taniwha and his flat stick piece of pounamu, what a manus. Bro, onion dips are really wicked good with bloody rugby balls, aye. You have no idea how stoked our mean as Hei-tikis were aye. Every time I see those hammered foreshore and seabed issues it's like Lake Taupo all over again aye, sink some piss. Anyway, Rhys Darby is just Jonah Lomu in disguise, to find the true meaning of life, one must start rooting with the old man's beard, mate. After the mince pie is skived off, you add all the tip-top girl guide biscuits to the Longest Drink in Town you've got yourself a meal. Technology has allowed pretty suss sheilas to participate in the global conversation of chronic utes. The next Generation of rough as guts munters have already munted over at smoko time. What's the hurry Hairy Maclary from Donaldson's Dairy? There's plenty of All Blacks in the wop wops. The sausage sizzle holds the most solid rimu community in the country.. Maui was burning my Vogel's when the epic cruising for a brusing event occured. See you right, this sweet bloke is as hard case as a bung scarfie. Mean while, in a waka, Dr Ropata and James and the Giant Peach were up to no good with a bunch of shithouse giant wekas. The carked it force of his reffing the game was on par with Jim Hickey's rip-off wifebeater singlet. Put the jug on will you bro, all these beached as native vegetables can wait till later. Across the ditch. The first prize for packing a sad goes to... Manus Morissette and his thermo-nuclear Jafa, what a cheeky darkie. Bro, vivids are really mint good with sweet as Bell Birds, aye. You have no idea how nuclear-free our stuffed pieces of cheese on toast were aye. Every time I see those stink chocolate fishes it's like Pack n' Save all over again aye, oh stink buzz. Anyway, Mrs Falani is just John Key in disguise, to find the true meaning of life, one must start whale watching with the milk, mate. After the jersey is flogged, you add all the pearler Grandpa's slippers to the lamington you've got yourself a meal. Technology has allowed paru Maoris to participate in the global conversation of crook gumboots. The next Generation of random stink buzzes have already packed a sad over at the tinny house.";
        const string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam mollis lorem ac viverra egestas. Donec ac rutrum lorem. Maecenas eu erat commodo, suscipit libero imperdiet, rhoncus metus. Sed posuere venenatis velit quis condimentum. Etiam placerat vel orci sit amet dignissim. Mauris a molestie augue. Vestibulum feugiat, enim eu luctus dapibus.";

        [TestMethod]
        public void EmptyCorpus()
        {
            var corpus = string.Empty;
            var term = "Lorem ipsum";

            var expectedPositions = corpus.indexesOf(term);

            CollectionAssert.AreEqual(expectedPositions.ToList(), new List<int>());
        }

        [TestMethod]
        public void EmptyTerm()
        {
            var corpus = "Lorem ipsum";
            var term = string.Empty;

            var expectedPositions = corpus.indexesOf(term);

            CollectionAssert.AreEqual(expectedPositions.ToList(), new List<int>());
        }

        [TestMethod]
        public void CorpusDoesNotContainTerm()
        {
            var corpus = baconIpsum;
            var term = "Tama and James Cook";

            var expectedPositions = corpus.indexesOf(term);

            CollectionAssert.AreEqual(expectedPositions.ToList(), new List<int>());

        }

        [TestMethod]
        public void TermLongerThanCorpus()
        {
            var corpus = "Tama and James Cook";
            var term = "Tama and James Cook were up to no good.";

            var expectedPositions = corpus.indexesOf(term);

            CollectionAssert.AreEqual(expectedPositions.ToList(), new List<int>());
        }

        [TestMethod]
        public void CorpusContains1Term()
        {
            var corpus = kiwiIpsum;
            var term = "snarky";

            var expectedPositions = corpus.indexesOf(term);
            
            Assert.AreEqual(expectedPositions.Count, 1);
        }

        [TestMethod]
        public void CorpusContains2Terms()
        {
            var corpus = baconIpsum;
            var term = "bacon";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.Count, 2);
        }

        [TestMethod]
        public void CorpusContainsRepeatedTerms()
        {
            //Checks that repeated terms do not get missed by jumping too far after a match is found.
            
            var corpus = "Tama and JamesjamesJaMesjAmEs were up to no good.";
            var term = "James";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.Count(), 4);
        }

        [TestMethod]
        public void CorpusContainsTermAtStart()
        {
            var corpus = kiwiIpsum;
            var term = "Kia ora";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.First(), 0);
        }

        [TestMethod]
        public void CorpusContainsTermAtEnd()
        {
            var corpus = baconIpsum;
            var term = "alcatra pig.";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.First(), (corpus.Length - term.Length));
        }

        [TestMethod]
        public void CorpusEqualsTerm()
        {
            var corpus = "alcatra pig.";
            var term = "alcatra pig.";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.First(), 0);
        }

        [TestMethod]
        public void MatchesAreCaseInsensitive()
        {
            var corpus = "Tama and James james JaMes jAmEs were up to no good.";
            var term = "James";

            var expectedPositions = corpus.indexesOf(term);

            Assert.AreEqual(expectedPositions.Count(), 4);
        }
    }
}
