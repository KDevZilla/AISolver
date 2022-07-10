# AISolver
This is a project that uses Artificial Intelligence to solve the problem.

# Project Details


## KnapSack
(https://en.wikipedia.org/wiki/Knapsack_problem)

You have $1250\
This is list of item prices :30,50,75,150,200,300\
How many items do you need to choose to make the summary be $1250\
if you cannot make it, can you please just choose the value close to $1250 as much as you can?


Here is the answer from using Genetic Algorithm.\
300,300,200,150,75,50,50,50,50,30


You can try it yourself with other values.
![Image Image](https://raw.githubusercontent.com/KDevZilla/Resource/main/AISolver_KnapSack_01.png)

## Bucket Calculation
There are 30 liters of water in the well.\
There are 2 buckets the first one can contain 5 liters, the second can contain 6 liters.\
You would like to have 3 liters of water\
How do you do?

Here is an answer from using the BreathFirst search algorithm. 
Move From Well to Bucket[5]\
B[6]0\
B[5]5

Move From Bucket[5] to Bucket[6]\
B[6]5\
B[5]0

Move From Well to Bucket[5]\
B[6]5\
B[5]5

Move From Bucket[5] to Bucket[6]\
B[6]6\
B[5]4

Move From Bucket[6] to Well\
B[6]0\
B[5]4

Move From Bucket[5] to Bucket[6]\
B[6]4\
B[5]0

Move From Well to Bucket[5]\
B[6]4\
B[5]5

Move From Bucket[5] to Bucket[6]\
B[6]6\
B[5]3

Move From Bucket[6] to Well\
B[6]0\
B[5]3

You can try it yourself with other values.
![Image Image](https://raw.githubusercontent.com/KDevZilla/Resource/main/AISolver_BucketCalculation_01.png)
## Crossing the river problems

	There are 5 problems relates to crossing the river.
	(https://en.wikipedia.org/wiki/Crossing_the_River)
	
1.There are 6 frogs
3 of them are on the left side another 3 of them are on the right side. 
3 from the left have to jump on the 3 stones on the right and vice versa 
Each frog can jump just on the adjacent stone or jump over another frog if there is an empty stone behind it


2.Four people come to a river in the night. 
There is a narrow bridge, 
but it can only hold two people at a time. 
They have one torch and, because it's night, 
the torch has to be used when crossing the bridge. 

Dad can cross the bridge in 1 minute, 
Mom in 2 minutes, 
Son in 4 minutes, 
Daughter in 5 minutes. 

When two people cross the bridge together, 
they must move at the slower person's pace. 
The question is, can they all get across the bridge if the torch lasts only 12 minutes


3.These 8 people need to use the raft to cross the river.
Father, Mother, Son1, Son2, Daughter1, Daughter2, Policeman, Thief

The problem is
1. Only 2 people on the raft at a time.
2. The Father cannot stay with any of the daughters, without their Mother's presence.
3. The Mother cannot stay with any of the sons, without their Father's presence.
4. The thief (striped shirt) cannot stay with any family member, if the Policeman is not there.
5. Only the Father, the Mother and the Policeman know how to operate the raft.

4.Three married couple come to a river. The only vessel available is a small boat
that can carry at most two of them. How can they cross the river, if at any time,
no woman is in the company of any man unless her own husband is present?

5.There are 6 animals need to use a raft to cross the rivers.
Those 6 animals consist of 3 Lions and 3 Sheeps.

The problem is
1. The raft can contain only most 2 animals.
2. The raft cannot move by itself, it requires at least one animal to control it.
3. If the number of lions is more than the number of sheeps, the lions will eat the sheeps then they fail.
4. Rule #3 apply to both side of the river and also on the raft.

![Image Image](https://raw.githubusercontent.com/KDevZilla/Resource/main/AISolver_Crossing_River_01.png)
====================================

# How to setup a project
1. Just download a project, it is just a small program written in C# Windows Form.

# File Structurs in this project
BreathFirst folder contains programs relate to Bucket calculation.\
DFS folder contains programs relate to Crossing River problems.\
GA folder contains programs relate to KnapSack problem.
