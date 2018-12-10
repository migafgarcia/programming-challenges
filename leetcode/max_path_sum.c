
int max_path(struct TreeNode* node, int* max) {
	if(!node) return 0;
    
	int left = max_path(node->left, max);
    left = left < 0 ? 0 : left;
    
	int right = max_path(node->right, max);
    right = right < 0 ? 0 : right;
    
    int val = left + right + node->val;
	*max = *max > val ? *max : val;;
	return node->val + (left > right ? left : right);
}

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
int maxPathSum(struct TreeNode* root) {
    int max = INT_MIN;
	max_path(root, &max);
	return max;
}