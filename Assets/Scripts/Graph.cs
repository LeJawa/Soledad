using System.Collections.Generic;
using UnityEngine;

class Graph<T> {

    List<T> nodes;
    Dictionary<T, List<T>> edges;

    public Dictionary<T, List<T>> Edges { get => edges; }

    public Graph () {
        nodes = new List<T>();
        edges = new Dictionary<T, List<T>>();
    }

    public bool AddNode(T newNode) {
        if ( nodes.Contains(newNode) ) {
            return false;
        }

        nodes.Add(newNode);
        edges.Add(newNode, new List<T>());
        return true;
    }

    public bool AddEdge(T node1, T node2) {
        if ( !nodes.Contains(node1) || !nodes.Contains(node2) ) {
            return false;
        }
        if ( edges[node1].Contains(node2) ) {
            return true;
        }

        edges[node1].Add(node2);
        edges[node2].Add(node1);
        return true;
    }

    public bool EdgeExistsBetween(T node1, T node2) {
        return edges[node1].Contains(node2);
    }

    public bool RemoveEdge(T node1, T node2) {
        return SafeRemoveEdge(node1, node2);
    }

    private bool SafeRemoveEdge(T node1, T node2) {
        if ( !nodes.Contains(node1) || !nodes.Contains(node2) ) {
            return false;
        }
        if ( !edges[node1].Contains(node2) ) {
            return true;
        }

        return UnsafeRemoveEdge(node1, node2);
    }

    private bool UnsafeRemoveEdge(T node1, T node2) {
        edges[node1].Remove(node2);
        edges[node2].Remove(node1);
        return true;
    }

    public bool RemoveNode(T oldNode) {
        if ( !nodes.Contains(oldNode) ) {
            return false;
        }

        foreach ( T node in edges[oldNode] ) {
            UnsafeRemoveEdge(node, oldNode);
        }

        nodes.Remove(oldNode);
        return true;
    }




}

