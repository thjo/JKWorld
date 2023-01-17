ref. 
https://www.w3schools.com/cpp/cpp_intro.asp
https://www.tutorialspoint.com/cplusplus/cpp_for_loop.htm

[Min Coding]
https://pro.mincoding.co.kr/
	>> Sign-up please......


[1st Step.]
1. io stream
  - cout << 'variable'
  - cin >> 'variable'

2. variable / 
  - declare 
  - initiate 
  - assign

-----------------------------------
Data Types
-----------------------------------
1. Primitive Built-in Types
Type					Typical Bit Width	Typical Range
char					1byte				-127 to 127 or 0 to 255
unsigned char			1byte				0 to 255
signed char				1byte				-127 to 127
int						4bytes				-2147483648 to 2147483647
unsigned int			4bytes				0 to 4294967295
signed int				4bytes				-2147483648 to 2147483647
short int				2bytes				-32768 to 32767
unsigned short int		2bytes				0 to 65,535
signed short int		2bytes				-32768 to 32767
long int				8bytes				-9223372036854775808 to 9223372036854775807
signed long int			8bytes				same as long int
unsigned long int		8bytes				0 to 18446744073709551615
long long int			8bytes				-(2^63) to (2^63)-1
unsigned long long int	8bytes				0 to 18,446,744,073,709,551,615
float					4bytes	
double					8bytes	
long double				12bytes	
wchar_t					2 or 4 bytes		1 wide character


int main() {
   cout << "Size of char : " << sizeof(char) << endl;
   cout << "Size of int : " << sizeof(int) << endl;
   cout << "Size of short int : " << sizeof(short int) << endl;
   cout << "Size of long int : " << sizeof(long int) << endl;
   cout << "Size of float : " << sizeof(float) << endl;
   cout << "Size of double : " << sizeof(double) << endl;
   cout << "Size of wchar_t : " << sizeof(wchar_t) << endl;
   
   return 0;
}

int main() {
    std::cout << "Int Min " << std::numeric_limits<int>::min() << endl;
    std::cout << "Int Max " << std::numeric_limits<int>::max() << endl;
    std::cout << "Unsigned Int  Min " << std::numeric_limits<unsigned int>::min() << endl;
    std::cout << "Unsigned Int Max " << std::numeric_limits<unsigned int>::max() << endl;
    std::cout << "Long Int Min " << std::numeric_limits<long int>::min() << endl;
    std::cout << "Long Int Max " << std::numeric_limits<long int>::max() << endl;

    std::cout << "Unsigned Long Int Min " << std::numeric_limits<unsigned  long int>::min() <<endl;
    std::cout << "Unsigned Long Int Max " << std::numeric_limits<unsigned  long int>::max() << endl;
}

2. typedef Declarations
  - You can create a new name for an existing type using typedef. Following is the simple syntax to define a new type using typedef −
		typedef type newname; 
  ex.
	typedef int feet;
	feet distance;

3. Enumerated Types
  - enum enum-name { list of names } var-list; 
  ex. 
	enum color { red, green, blue } c;
c = blue;
-----------------------------------
Variable Types
-----------------------------------
  - Enumeration, Pointer, Array, Reference, Data structures, and Classes.
  ex. 
	// Variable declaration:
	extern int a, b;
	extern int c;
	extern float f;
  
	int main () {
		// Variable definition:
		int a, b;
		int c;
		float f;
 
		// actual initialization
		a = 10;
		b = 20;
		c = a + b;
 
		cout << c << endl ;

		f = 70.0/3.0;
		cout << f << endl ;
 
		return 0;
	}
-----------------------------------
Variable Scope
-----------------------------------
1. Local Variables
  - Variables that are declared inside a function or block are local variables. 
  They can be used only by statements that are inside that function or block of code. 
  Local variables are not known to functions outside their own
2. Global Variables
  - Global variables are defined outside of all the functions, usually on top of the program. 
  The global variables will hold their value throughout the life-time of your program.
  A global variable can be accessed by any function. That is, a global variable is available for use throughout your entire program after its declaration.
-----------------------------------


3. operations
-----------------------------------
1. Arithmetic Operators
Operator	Description														Example
+			Adds two operands												A + B will give 30
-			Subtracts second operand from the first							A - B will give -10
*			Multiplies both operands										A * B will give 200
/			Divides numerator by de-numerator								B / A will give 2
%			Modulus Operator and remainder of after an integer division		B % A will give 0
++			Increment operator, increases integer value by one				A++ will give 11
--			Decrement operator, decreases integer value by one				A-- will give 9

2. Relational Operators
Operator	Description																															Example
==			Checks if the values of two operands are equal or not, if yes then condition becomes true.											(A == B) is not true.
!=			Checks if the values of two operands are equal or not, if values are not equal then condition becomes true.							(A != B) is true.
>			Checks if the value of left operand is greater than the value of right operand, if yes then condition becomes true.					(A > B) is not true.
<			Checks if the value of left operand is less than the value of right operand, if yes then condition becomes true.					(A < B) is true.
>=			Checks if the value of left operand is greater than or equal to the value of right operand, if yes then condition becomes true.		(A >= B) is not true.
<=			Checks if the value of left operand is less than or equal to the value of right operand, if yes then condition becomes true.		(A <= B) is true.

3. Logical Operators
Operator	Description																																				Example
&&			Called Logical AND operator. If both the operands are non-zero, then condition becomes true.															(A && B) is false.
||			Called Logical OR Operator. If any of the two operands is non-zero, then condition becomes true.														(A || B) is true.
!			Called Logical NOT Operator. Use to reverses the logical state of its operand. If a condition is true, then Logical NOT operator will make false.		!(A && B) is true.

4. Bitwise Operators
p		q		p & q	p | q	p ^ q
0		0		  0		  0		  0
0		1		  0		  1		  1
1		1		  1		  1		  0
1		0		  0		  1		  1
Operator	Description																															Example
&			Binary AND Operator copies a bit to the result if it exists in both operands.														(A & B) will give 12 which is 0000 1100
|			Binary OR Operator copies a bit if it exists in either operand.																		(A | B) will give 61 which is 0011 1101
^			Binary XOR Operator copies the bit if it is set in one operand but not both.														(A ^ B) will give 49 which is 0011 0001
~			Binary Ones Complement Operator is unary and has the effect of 'flipping' bits.														(~A ) will give -61 which is 1100 0011 in 2's complement form due to a signed binary number.
<<			Binary Left Shift Operator. The left operands value is moved left by the number of bits specified by the right operand.				A << 2 will give 240 which is 1111 0000
>>			Binary Right Shift Operator. The left operands value is moved right by the number of bits specified by the right operand.			A >> 2 will give 15 which is 0000 1111

5. Assignment Operators
  =, +=, -=, *=, /=, %=, <<=, >>=, &=, ^=, |=

6. Misc Operators
  1) sizeof
    - sizeof operator returns the size of a variable. For example, sizeof(a), where ‘a’ is integer, and will return 4.
  2) Condition ? X : Y
    - Conditional operator (?). If Condition is true then it returns value of X otherwise returns value of Y.
  3) ,
    - Comma operator causes a sequence of operations to be performed. The value of the entire comma expression is the value of the last expression of the comma-separated list.
  4) . (dot) and -> (arrow)
    - Member operators are used to reference individual members of classes, structures, and unions.
  5) Cast
    - Casting operators convert one data type to another. For example, int(2.2000) would return 2.
  6) &
    - Pointer operator & returns the address of a variable. For example &a; will give actual address of the variable.
  7) *
    - Pointer operator * is pointer to a variable. For example *var; will pointer to a variable var.
-----------------------------------
4. comments


5. if & if-else
	- condition:: 0 is only false, other values are true

-----------------------------------
  optional. switch - case
-----------------------------------
	switch (variable/expression) {
		case 1:
		//statement(s) to execute
		break;
		case 2:
		//statement(s) to execute
		break;
		.....
		.....
		.....
		default:
		//statement(s) to execute
		;
	}
-----------------------------------


6. iteration
  1) for loop
  for(initialization; condition expression; update expression) {
	//code block to be executed
  }
  2) coninue & break

-----------------------------------
  optional. while loop
-----------------------------------
	while(condition) {
	//statement(s);
	}
-----------------------------------
  optional. do while loop
-----------------------------------
  optional. nested loops
-----------------------------------


7. array
  - which stores a fixed-size sequential collection of elements of the same type. 
  1) Declaring Arrays
    - type arrayName [ arraySize ];
	ex. 
		double balance[10];
  2) Initializing Arrays
    - ou can initialize C++ array elements either one by one or using a single statement
	ex.
		double balance[5] = {1000.0, 2.0, 3.4, 17.0, 50.0};
		double balance[] = {1000.0, 2.0, 3.4, 17.0, 50.0};
  3) Accessing Array Elements
    - An element is accessed by indexing the array name. This is done by placing the index of the element within square brackets after the name of the array.
	ex.
		double salary = balance[9];
  4) few important concepts
    - Multi-dimensional arrays
		ex. int arr[3][5] = {{1, 2, 3, 4, 5}, {2, 3, 4, 5, 6}, {3, 4, 5, 6, 7}};
	- Pointer to an arry
	- Passing arrays to functions
	- Return array from functions


8. Functions
  - A function is a group of statements that together perform a task. 
  Every C++ program has at least one function, which is main(), and all the most trivial programs can define additional functions.
  1) Defining a Function
    - The general form of a C++ function definition is as follows −
	return_type function_name( parameter list ) {
		body of the function
	}
	ex.
		// function returning the max between two numbers
		int max(int num1, int num2) {
			// local variable declaration
			int result;
			if (num1 > num2)
				result = num1;
			else
				result = num2;
			return result; 
		}

  2) Function Declarations
    - A function declaration tells the compiler about a function name and how to call the function. The actual body of the function can be defined separately.
	return_type function_name( parameter list );
	ex.
		int max(int num1, int num2);

  3) Function Arguments
    - Call by Value
		:: This method copies the actual value of an argument into the formal parameter of the function. In this case, changes made to the parameter inside the function have no effect on the argument.
	- Call by Pointer
		:: This method copies the address of an argument into the formal parameter. Inside the function, the address is used to access the actual argument used in the call. This means that changes made to the parameter affect the argument.
	- Call by Reference
		:: This method copies the reference of an argument into the formal parameter. Inside the function, the reference is used to access the actual argument used in the call. This means that changes made to the parameter affect the argument

