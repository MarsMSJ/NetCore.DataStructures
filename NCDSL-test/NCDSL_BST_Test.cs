using System;
using System.Collections;
using Xunit;
using NCDSL;

namespace NCDSL_test
{
    public class NCDSL_BST_Test
    {
        const int Min = 1;
        const int MAX = 9;
        static BST<int> BST_;
        static IEnumerable TestSequence;
        static IEnumerable PreOrderSequence;
        static IEnumerable PostOrderSequence;
        static IEnumerable InOrderSequence;
        static IEnumerable LevelOrderSequence;
        
        
        
        static NCDSL_BST_Test()
        {
            TestSequence = new int[]{ 5, 1, 4, 6, 4, 7, 3, 6, 8, 9 };            
            PreOrderSequence = new int[]{ 5, 1, 4, 3, 4, 6, 7, 6, 8, 9 };
            PostOrderSequence = new int[]{ 3, 4, 4, 1, 6, 9, 8, 7, 6, 5 };
            InOrderSequence = new int[]{ 1, 3, 4, 4, 5, 6, 6, 7, 8, 9 };
            LevelOrderSequence = new int[]{ 5, 1, 6, 4, 7, 3, 4, 6, 8, 9 };
            BST_ = new BST<int>();
        }
        
        [Fact] 
        public void SuperTest()
        {
            
        }
        
        
        [Fact]
        public void TestTreeInsert()
        {
            if( !BST_.IsEmpty )
            {
                BST_.Clear();
            }
            foreach( int element in TestSequence )
            {
                BST_.Insert( element );
                Assert.True( BST_.Contains( element ) );
            }
        }
        
        [Fact]
        public void TestInOrderTreeTransversal()
        {
            if( BST_.IsEmpty )
            {
                foreach( int element in TestSequence )
                {
                    BST_.Insert( element );                
                }
            }
            
            var test = BST_.GetInOrder();
            Assert.Equal( test, InOrderSequence );
        }
        
        [Fact]
        public void TestPostOrderTreeTransversal()
        {
            if( BST_.IsEmpty )
            {
                foreach( int element in TestSequence )
                {
                    BST_.Insert( element );                
                }
            }
            
            var test = BST_.GetPostOrder();
            Assert.Equal( test, PostOrderSequence );
        }
        
        [Fact]
        public void TestPreOrderTransversal()
        {
             if( BST_.IsEmpty )
            {
                foreach( int element in TestSequence )
                {
                    BST_.Insert( element );                
                }
            }
            
            var test = BST_.GetPreOrder();
            Assert.Equal( test, PreOrderSequence );
        }
        
    
    }
}
