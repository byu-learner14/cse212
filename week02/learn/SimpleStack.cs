var stack = new Stack<int>();

stack.Push(1);   // [1]
stack.Push(2);   // [1, 2]
stack.Push(3);   // [1, 2, 3]

stack.Pop();     // removes 3 → [1, 2]
stack.Pop();     // removes 2 → [1]

stack.Push(4);   // [1, 4]
stack.Push(5);   // [1, 4, 5]

stack.Pop();     // removes 5 → [1, 4]

stack.Push(6);   // [1, 4, 6]
stack.Push(7);   // [1, 4, 6, 7]
stack.Push(8);   // [1, 4, 6, 7, 8]
stack.Push(9);   // [1, 4, 6, 7, 8, 9]

stack.Pop();     // removes 9 → [1, 4, 6, 7, 8]
stack.Pop();     // removes 8 → [1, 4, 6, 7]

stack.Push(10);  // [1, 4, 6, 7, 10]

stack.Pop();     // removes 10 → [1, 4, 6, 7]
stack.Pop();     // removes 7 → [1, 4, 6]
stack.Pop();     // removes 6 → [1, 4]

stack.Push(11);  // [1, 4, 11]
stack.Push(12);  // [1, 4, 11, 12]

stack.Pop();     // removes 12 → [1, 4, 11]
stack.Pop();     // removes 11 → [1, 4]
stack.Pop();     // removes 4 → [1]

stack.Push(13);  // [1, 13]
stack.Push(14);  // [1, 13, 14]
stack.Push(15);  // [1, 13, 14, 15]
stack.Push(16);  // [1, 13, 14, 15, 16]

stack.Pop();     // removes 16 → [1, 13, 14, 15]
stack.Pop();     // removes 15 → [1, 13, 14]
stack.Pop();     // removes 14 → [1, 13]

stack.Push(17);  // [1, 13, 17]
stack.Push(18);  // [1, 13, 17, 18]

stack.Pop();     // removes 18 → [1, 13, 17]

stack.Push(19);  // [1, 13, 17, 19]
stack.Push(20);  // [1, 13, 17, 19, 20]

stack.Pop();     // removes 20 → [1, 13, 17, 19]
stack.Pop();     // removes 19 → [1, 13, 17]