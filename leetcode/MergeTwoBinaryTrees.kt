
class Solution {

    fun mergeTrees(t1: TreeNode?, t2: TreeNode?): TreeNode? {

        var merged : TreeNode?

        if(t1 != null && t2 != null) {
            merged = TreeNode(t1.`val` + t2.`val`)
        }
        else if(t1 != null) {
            merged = TreeNode(t1.`val`)
        }
        else if(t2 != null) {
            merged = TreeNode(t2.`val`)
        }
        else {
            return null
        }

        merged.left = mergeTrees(t1?.left, t2?.left)
        merged.right = mergeTrees(t1?.right, t2?.right)

        return merged
    }

}