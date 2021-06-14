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
