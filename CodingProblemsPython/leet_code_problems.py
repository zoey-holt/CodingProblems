from typing import List
import itertools
import sys

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

# 4. Median of Two Sorted Arrays
# Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
# The overall run time complexity should be O(log(M + N)).
def find_median_sorted_arrays(nums1: List[int], nums2: List[int]) -> float:
    if len(nums2) < len(nums1): # ensure nums2 is always the larger array
        throw_away = nums1
        nums1 = nums2
        nums2 = throw_away
    lo = 0
    hi = len(nums1)
    while lo <= hi:
        part1 = int((lo + hi) / 2)
        part2 = int((len(nums1) + len(nums2) + 1) / 2) - part1
        nums1_lmax = -sys.maxsize if part1 == 0 else nums1[part1 - 1]
        nums1_rmin = sys.maxsize if part1 == len(nums1) else nums1[part1]
        nums2_lmax = -sys.maxsize if part2 == 0 else nums2[part2 - 1]
        nums2_rmin = sys.maxsize if part2 == len(nums2) else nums2[part2]
        if nums1_lmax <= nums2_rmin and nums2_lmax <= nums1_rmin:
            return (max(nums1_lmax, nums2_lmax) + min(nums1_rmin, nums2_rmin)) / 2 if (len(nums1) + len(nums2)) % 2 == 0 else max(nums1_lmax, nums2_lmax)
        elif nums1_lmax > nums2_rmin:   hi = part1 - 1
        else:   lo = part1 + 1
    return 0

# 26. Remove Duplicates from Sorted Array
# Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
# Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
# Return k after placing the final result in the first k slots of nums.
# Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
def remove_duplicates(nums: List[int]) -> int:
    if not nums: return 0
    k = 1
    for i, n in enumerate(nums):
        if i == 0 or n == nums[i-1]: continue
        nums[k] = n
        k += 1
    return k

# 27. Remove Element
# Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.
# Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
# Return k after placing the final result in the first k slots of nums.
# Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
def remove_element(nums: List[int], val: int) -> int:
    i1 = 0
    i2 = 0
    while i1 < len(nums):
        if nums[i1] == val:
            i2 += 1
        else:
            nums[i1 - i2] = nums[i1]
        i1 += 1
    return i1 - i2

# 36. Valid Sudoku
# Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
# Each row must contain the digits 1-9 without repetition.
# Each column must contain the digits 1-9 without repetition.
# Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
# A Sudoku board (partially filled) could be valid but is not necessarily solvable.
# Only the filled cells need to be validated according to the mentioned rules.
def is_valid_sudoku(board: List[List[str]]) -> bool:
    for row in board:
        if not is_valid_sudoku_section(row):
            return False
    for col in zip(*board):
        if not is_valid_sudoku_section(col):
            return False
    boxes = [[],[],[],[],[],[],[],[],[]]
    for i, row in enumerate(board):
        for x in range(0, 3):
            boxes[int(i/3)+(x*3)] += [row[x],row[x+1],row[x+2]]
    for box in boxes:
        if not is_valid_sudoku_section(box):
            return False
    return True

def is_valid_sudoku_section(section: List[str]) -> bool:
    checked = []
    for n in section:
        if n != '.':
            if n in checked:
                return False
            checked.append(n)
    return True

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

    def to_level_order_array(self) -> List[int]:
        array = []
        current_level = [self]
        while current_level:
            array += [n if n is None else n.val for n in current_level]
            next_level = []
            for n in current_level:
                if n and (n.left or n.right):
                    if n.left: next_level.append(n.left)
                    else: next_level.append(None)
                    if n.right: next_level.append(n.right)
                    else: next_level.append(None)
            current_level = next_level
        return array

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
def binary_tree_level_order(root: TreeNode) -> List[List[int]]:
    if not root:
        return []
    result = []
    current_level = [root]
    while current_level:
        result.append([n.val for n in current_level])
        next_level = []
        for node in current_level:
            if node.left:  next_level.append(node.left)
            if node.right: next_level.append(node.right)
        current_level = next_level
    return result

# 124. Binary Tree Maximum Path Sum
# A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.
# The path sum of a path is the sum of the node's values in the path.
# Given the root of a binary tree, return the maximum path sum of any path.
# Example 1:
# Input: root = [1,2,3]
# Output: 6
# Explanation: The optimal path is 2 -> 1 -> 3 with a path sum of 2 + 1 + 3 = 6.
# Example 2:
# Input: root = [-10,9,20,None,None,15,7]
# Output: 42
# Explanation: The optimal path is 15 -> 20 -> 7 with a path sum of 15 + 20 + 7 = 42.
# Constraints:
# The number of nodes in the tree is in the range [1, 3 * 104].
# -1000 <= Node.val <= 1000
def max_path_sum(self, root: TreeNode) -> int:
    pass

# 297. Serialize and Deserialize Binary Tree
# Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
# Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
# Clarification: The input/output format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
# Input: root = [1,2,3,None,None,4,5]
# Output: [1,2,3,None,None,4,5]
# Input: root = []
# Output: []
# Input: root = [1]
# Output: [1]
# Input: root = [1,2]
# Output: [1,2]
# The number of nodes in the tree is in the range [0, 104].
# -1000 <= Node.val <= 1000
def serialize_binary_tree(root: TreeNode) -> str:
    pass        

def deserialize_binary_tree(data: str) -> TreeNode:
    pass

# 429. N-ary Tree Level Order Traversal
# Given an n-ary tree, return the level order traversal of its nodes' values.
class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children = children or []
        self.seen = False
        
    # Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value.
    def from_level_order_array(array: List[int]):
        if not array:
            return None
        root = Node(array[0])
        branches = [root]
        for value in array[2:]:
            if value is not None:
                node = Node(value)
                branches[0].children.append(node)
                branches.append(node)
            else:
                branches.pop(0)
        return root

def nary_tree_level_order(root: Node) -> List[List[int]]:
    if not root:
        return []
    result = []
    current_level = [root]
    while current_level:
        result.append([n.val for n in current_level])
        next_level = []
        for node in current_level:
            next_level += node.children
        current_level = next_level
    return result

# 1004. Max Consecutive Ones III
# Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
# TODO: This is still not quite a correct answer.
def longest_ones(nums: List[int], k: int) -> int:
    longest = 0
    group_indicies = get_one_group_indicies(nums)
    lens = []
    for i, group in enumerate(group_indicies):
        a = longest_one_sliding_window(group_indicies, group, i, k, len(nums))
        lens.append(a)
        longest = max(longest, a)
    return longest

def get_one_group_indicies(nums: List[int]) -> List[int]:
    group_indicies = []
    in_one_group = False
    one_group = []
    for i, n in enumerate(nums):
        if not in_one_group and n == 1:
            one_group.append(i)
            in_one_group = True
        if in_one_group and n == 0:
            one_group.append(i)
            group_indicies.append(one_group)
            in_one_group = False
            one_group = []
    if one_group:
        one_group.append(len(nums))
        group_indicies.append(one_group)
    return group_indicies

def longest_one_sliding_window(grp_idxs: List[int], curr_grp: List[int], i: int, k: int, max_len: int) -> int:
    len_curr = curr_grp[1] - curr_grp[0]
    len_prev, dis_prev, len_next, dis_next = 0, 0, 0, 0
    prev_grp, next_grp = None, None
    if i > 0:
        prev_grp = grp_idxs[i-1]
        len_prev = prev_grp[1] - prev_grp[0]
        dis_prev = curr_grp[0] - prev_grp[1]
    if i < len(grp_idxs) - 1:
        next_grp = grp_idxs[i+1]
        len_next = next_grp[1] - next_grp[0]
        dis_next = next_grp[0] - curr_grp[1]

    if next_grp and dis_next <= k and (not prev_grp or len_next - dis_next > len_prev - dis_prev):
        new_len = len_curr + len_next + dis_next
        k -= dis_next
        new_grp = [curr_grp[0], next_grp[1]]
        new_grp_idxs = [gi for j, gi in enumerate(grp_idxs) if j != i + 1]
        new_i = i
    elif prev_grp and dis_prev <= k:
        new_len = len_curr + len_prev + dis_prev
        k -= dis_prev
        new_grp = [prev_grp[0], curr_grp[1]]
        new_grp_idxs = [gi for j, gi in enumerate(grp_idxs) if j != i - 1]
        new_i = i - 1
    else:
        new_len = min(len_curr + k, max_len)
        k = 0
        new_grp_idxs = []

    if k > 0 and new_grp_idxs:
        return longest_one_sliding_window(new_grp_idxs, new_grp, new_i, k, max_len)
    return new_len
