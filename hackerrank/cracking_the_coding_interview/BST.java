// https://www.hackerrank.com/challenges/ctci-is-binary-search-tree

/* Hidden stub code will pass a root argument to the function below. Complete the function to solve the challenge. Hint: you may want to write one or more helper functions.  

The Node class is defined as follows:
    class Node {
        int data;
        Node left;
        Node right;
     }
*/
    boolean checkBST(Node root) {
        
        return checkAux(root, Integer.MIN_VALUE, Integer.MAX_VALUE);
        
    }

boolean checkAux(Node node, int min, int max) {
    
    if(node == null)
        return true;
    
     //System.out.println("current = " + node.data + ", min = " + min + ", max = " + max);
    
    if(node.data <= min || node.data >= max)
        return false;
    
    return checkAux(node.left, min, node.data) && checkAux(node.right, node.data, max);
}
 
