# Lab 1: Stack Implementation Using Linked List in C#

## Overview

You are developing a stack implementation using a linked list in C#. The stack follows the **Last-In-First-Out (LIFO)** principle. The program defines a `Stack` class and a `Node` class to store the elements and maintain the references between nodes.

## Objective

The program should:
- Create a stack object
- Push elements onto the stack
- Pop elements from the top
- Peek at the element on the top without removing it

## Instructions

### Step 1: Import Required Namespace
Use the `System` namespace to gain access to the necessary classes and functions for input/output operations.

```csharp
using System;
```

### Step 2: Define a Node Class
Create a `Node` class with the following properties:
- `Value` - stores the node's data
- `Next` - reference to the next node in the stack

### Step 3: Define a Stack Class
Create a `Stack` class with:
- A private member variable `top` to represent the top of the stack
- Implement the following methods:
  - `IsEmpty()` - checks if the stack is empty
  - `Push(value)` - adds an element onto the stack
  - `Pop()` - removes and returns the element from the top of the stack
  - `Peek()` - retrieves the value of the top element without removing it

### Step 4: Create a Stack Object
Instantiate a `Stack` object called `myStack` to store the elements.

### Step 5: Push Elements onto the Stack
Use the `Push` method of the `myStack` object to add elements to the stack.

### Step 6: Pop Elements from the Stack
Use the `Pop` method of the `myStack` object to remove and return elements from the top of the stack.

### Step 7: Peek at the Top Element
Use the `Peek` method of the `myStack` object to retrieve the value of the top element without removing it.

### Step 8: Run the Program
Execute the program and observe the output as elements are pushed, popped, and peeked on the stack.

## Key Concepts

- **LIFO Principle**: Last-In-First-Out - the most recently added element is the first to be removed
- **Linked List**: Each node points to the next node, creating a chain of elements
- **Stack Operations**: Push (add), Pop (remove), Peek (view without removing)

## Expected Behavior

Your implementation should demonstrate:
1. Successfully pushing multiple elements
2. Popping elements in reverse order of insertion (LIFO)
3. Peeking at the top element without modifying the stack
4. Proper handling of empty stack conditions