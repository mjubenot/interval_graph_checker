# interval_graph_checker


This is a simple project which aim to detect irregularities in an interval graph.
It has been done in one week, after we worked on the graph theory.


# The model
The graph, in this program is represented by nodes, and each nodes have neighborhood.
In my model, there a no real "edge" to speak of, which isn't how the graph theory is supposed to work.
This model can represent all simple bidirectionnal non-weighted graph, but not the others.


# What does it do ?

To create a graph, you can edit the Program.cs file, create node, and add their neighborhood.
There are examples in the code.

The code will output all detected cycle and then all irregular cycles.
The detected cycle cannot go back to the same point twice.

The data model is reusable to detect Path intead of Cycle.

# There's more ?!
Yup, there's also a Djikstra implemented to find all path from one point. It's represented by the Path object which instantiate himself under some condition.

This project is on a hold for now.

# Things to do
- Change the data model to include proper edge
- Comment

