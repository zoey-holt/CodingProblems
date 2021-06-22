from typing import List

# 1. Two Sum
# Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
# You can return the answer in any order.
# This solution has a time complexity of O(N) where N = nums.Length.
# This solution has a space complexity of O(N) where N = nums.Length.
def two_sum(nums: List[int], target: int) -> List[int]:
    d = {}
    for i, n in enumerate(nums):
        x = target - n
        if x in d:
            return [d[x], i]
        else:
            d[n] = i
    return []

# 2. Add Two Numbers
# You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
# You may assume the two numbers do not contain any leading zero, except the number 0 itself.
class ListNode:
    def __init__(self, val=0, next=None, values=None):
        if values:
            start = ListNode()
            node = start
            for i, v in enumerate(values):
                node.val = v
                if i == len(values) - 1:
                    break
                node.next = ListNode()
                node = node.next
            self.val = start.val
            self.next = start.next
        else:
            self.val = val
            self.next = next

    def to_array(self):
        result = []
        node = self
        while True:
            result.append(node.val)
            node = node.next
            if node is None:
                return result

def add_two_numbers(l1: ListNode, l2: ListNode) -> ListNode:
    head = ListNode()
    a = l1
    b = l2
    c = head
    carry = False
    while a or b or carry:
        sum = (a.val if a else 0) + (b.val if b else 0)
        if carry:
            sum += 1
            carry = False
        if sum > 9:
            carry = True
            sum -= 10
        c.val = sum
        a = a.next if a else None
        b = b.next if b else None
        if a or b or carry:
            c.next = ListNode()
            c = c.next
    return head

# 3. Longest Substring Without Repeating Characters
# Given a string s, find the length of the longest substring without repeating characters.
def length_of_longest_substring(s: str) -> int:
    longest = 0
    for i in range(0, len(s)):
        if i + longest >= len(s):
            break
        chars = set()
        broke = False
        for j in range(i, len(s)):
            if s[j] in chars:
                if j - i > longest:
                    longest = j - i
                chars = set()
                broke = True
                break
            else:
                chars.add(s[j])
        if not broke and len(s) - i > longest:
            longest = len(s) - i
    return longest

# 94. Binary Tree Inorder Traversal
# Given the root of a binary tree, return the inorder traversal of its nodes' values.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

    def from_level_order_array(array: List[int]):
        if not array:
            return None
        root = TreeNode(array[0])
        branches = [root]
        left = True
        for value in array[1:]:
            if left:
                if value is not None:
                    node = TreeNode(value)
                    branches[0].left = node
                    branches.append(node)
            else:
                branch = branches.pop(0)
                if value is not None:
                    node = TreeNode(value)
                    branch.right = node
                    branches.append(node)
            left = not left
        return root

def inorder_traversal(root: TreeNode) -> List[int]:
    list = []
    if root:
        list.extend(inorder_traversal(root.left))
        list.append(root.val)
        list.extend(inorder_traversal(root.right))
    return list

# Follow up: Recursive solution is trivial, could you do it iteratively?
def inorder_traversal_iterative(root: TreeNode) -> List[int]:
    list = []
    stack = []
    current = root
    while True:
        if current:
            stack.append(current)
            current = current.left
        else:
            if not stack:
                break
            current = stack.pop()
            list.append(current.val)
            current = current.right
    return list
            
# 98. Validate Binary Search Tree
# Given the root of a binary tree, determine if it is a valid binary search tree (BST).
def is_valid_bst(root: TreeNode) -> bool:
    if not root:
        return True
    return is_valid_bst_subtree(root.left, None, root.val) and is_valid_bst_subtree(root.right, root.val, None)

def is_valid_bst_subtree(root: TreeNode, min: int, max: int) -> bool:
    if not root:
        return True
    if (max is not None and root.val >= max) or (min is not None and root.val <= min):
        return False
    return is_valid_bst_subtree(root.left, min, root.val) and is_valid_bst_subtree(root.right, root.val, max)

# 102. Binary Tree Level Order Traversal
# Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
def level_order(root: TreeNode) -> List[List[int]]:
    if not root:
        return []
    result = []
    current_level = [root]
    while current_level:
        result.append([n.val for n in current_level])
        next_level = []
        for n in current_level:
            if n.left:  next_level.append(n.left)
            if n.right: next_level.append(n.right)
        current_level = next_level
    return result
