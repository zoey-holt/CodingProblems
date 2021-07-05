from typing import List
from leet_code_problems import TreeNode

# 4.2 Minimal Tree
# Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height.
def to_minimal_bst(nums: List) -> TreeNode:
    if not nums: return None
    if len(nums) == 1: return TreeNode(nums[0])
    if len(nums) == 2: return TreeNode(nums[1], TreeNode(nums[0]))
    root_idx = int(len(nums) / 2)
    root = TreeNode(nums[root_idx])
    root.left = to_minimal_bst(nums[:root_idx])
    root.right = to_minimal_bst(nums[root_idx+1:])
    return root
