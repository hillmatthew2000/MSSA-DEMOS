# Queue Implementation Assignment

## Objective
Create a Queue data structure using a custom singly linked list implementation that stores integers and demonstrates FIFO (First In, First Out) behavior.

## Class Requirements

### Node Class
Create a `Node` class with the following properties:
- **Value**: An integer that stores the node's data
- **Next**: A reference to the next node in the linked list

### Queue Class
Implement a `Queue` class that uses the Node class internally and maintains:
- **Front**: Reference to the front (first) node of the queue
- **Rear**: Reference to the rear (last) node of the queue

## Method Implementation

### Enqueue Method
- **Purpose**: Add a new element to the rear of the queue
- **Parameters**: Integer value to be added
- **Behavior**:
  - Create a new Node with the given value
  - Add it to the rear of the linked list
  - If the queue is empty, set both front and rear to the new node
  - If the queue has elements, link the current rear node to the new node and update rear

### Dequeue Method
- **Purpose**: Remove and return the element at the front of the queue
- **Returns**: Integer value of the removed element
- **Behavior**:
  - Remove the node at the front of the list
  - Return its value
  - Update front to point to the next node
  - If the queue becomes empty after this operation, set rear to null
  - **Exception Handling**: Throw an exception if attempting to dequeue from an empty queue

### IsEmpty Method
- **Purpose**: Check if the queue contains any elements
- **Returns**: Boolean value
- **Logic**: Return true if front is null; otherwise, return false

## Main Method Demonstration

Implement the following sequence in your Main method to test the queue functionality:

1. **Initial Setup**: Create a new Queue instance

2. **Enqueue Operations**:
   - Enqueue the integer `1`
   - Enqueue the integer `2`
   - Enqueue the integer `3`

3. **First Dequeue Phase**:
   - Dequeue two elements
   - Print each dequeued value to the console

4. **Additional Enqueue**:
   - Enqueue the integer `4`

5. **Final Dequeue Phase**:
   - Dequeue all remaining elements
   - Print each dequeued value to the console
   - This should confirm that the queue preserves FIFO order

## Expected Output
The program should demonstrate that elements are removed in the same order they were added (FIFO principle). The expected sequence of dequeued values should be: 1, 2, 3, 4.

## Technical Notes
- Use proper exception handling for edge cases (empty queue operations)
- Ensure proper memory management by updating references correctly
- Test the IsEmpty method to verify queue state at different points
- Consider adding console output to show the current state of operations for better demonstration