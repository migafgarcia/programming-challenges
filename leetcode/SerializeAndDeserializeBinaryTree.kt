import java.util.LinkedList;

public class Codec {

    // Encodes a tree to a single string.
    public String serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();

        LinkedList<TreeNode> queue = new LinkedList<>();
        queue.add(root);

        while(!queue.isEmpty()) {

            TreeNode current = queue.poll();

            if(current == null) {
                sb.append("null|");
                continue;
            }

            queue.add(current.left);
            queue.add(current.right);

            sb.append(current.val);
            sb.append('|');

        }
        sb.deleteCharAt(sb.length() - 1);

        return sb.toString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(String data) {

        String[] nodeStrings = data.split("\\|");
        int currentString = 0;
        TreeNode head = stringToNode(nodeStrings[currentString++]);

        LinkedList<TreeNode> treeNodes = new LinkedList<>();
        treeNodes.add(head);

        while(currentString < nodeStrings.length) {
            TreeNode current = treeNodes.poll();
            current.left = stringToNode(nodeStrings[currentString++]);
            if(current.left != null)
                treeNodes.add(current.left);
            current.right = stringToNode(nodeStrings[currentString++]);
            if(current.right != null)
                treeNodes.add(current.right);

        }



        return head;
    }

    private TreeNode stringToNode(String s) {
        if(s.equals("null"))
            return null;
        else
            return new TreeNode(Integer.parseInt(s));
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));