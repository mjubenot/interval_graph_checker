# interval_graph_checker


This is a simple project which aim to detect irregularities in an interval graph.
The graph is represented by nodes, and each nodes have neighborhood. There a no real "edge" to speak of, which isn't how the graph theory is supposed to work. It worked for my use, but this data model for the graph is incorrect.


# What does it do ?

To create a graph, you can edit the Program.cs file, create node, and add their neighborhood.
There are examples in the code.

The code will output all detected cycle and then all irregular cycles.
The detected cycle cannot go back to the same point twice.

The data model is reusable to detect Path intead of Cycle, but as said earlier, it's not really the correct way to represent the graph theory.
