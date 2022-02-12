using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab1;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        AVL tree = new AVL();
        Node expectForAdd = new Node(5);
        const int expectForHeight = 2;
        const int expectForMax = 10;
        const Node expectForDelete = null;



        [TestMethod]
        public void AddTest() {
            tree.Add(5);
            
            Assert.AreEqual(expectForAdd.data, tree.root.data);
        }



        [TestMethod]
        public void GetHeightTest() {
            tree.Add(1);
            tree.Add(2);
            var height = tree.getHeight(tree.root);
            Assert.AreEqual(expectForHeight, height);

        }



        [TestMethod]
        public void DeleteTest() {
            tree.Delete(5);
            tree.Delete(1);
            tree.Delete(2);
            Assert.AreEqual(expectForDelete, tree.root);
        }



        [TestMethod]
        public void MaxTest() {          
            Assert.AreEqual(expectForMax, tree.max(10, 9));
        }
    }
}
