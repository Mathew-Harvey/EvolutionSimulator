using UnityEngine

public class NN: MonoBehaviour
{
    public Layer hidden1;
    public Layer hidden2;
    public Layer output;
    public class Layer
    {
        public float[,] WeightsArray;
        public float[] BiasesArray;
        public float[] nodeArray;

        private int n_nodes;
        private int n_inputs;

        public Layer(int n_inputs, int n_nodes)
        {
            this.n_nodes = n_nodes;
            this.n_inputs = n_inputs;

            weightsArray = new float[n_nodes, n_inputs];
            biasesArray = new float[n_nodes];
            nodeArray = new float[n_nodes];
        }

        // Forward pass = sum of the weights of the inputs multiplied by the biases
        public void Forward(float [] inputsArray)
        {
            nodeArray = new float[n_nodes];
            for (int i = 0; i < n_nodes; i++)
            {
                // sum of weights times inputs
                for(int j = 0; j < n_inputs; j++)
                {
                    nodeArray[i] += weightsArray[i,j] * inputsArray;
                }
                // add the bias
                nodeArray[i] += biasesArray[i];
            }
        }

        public void Activation()
        {
            for (int i = 0; i < n_nodes; i++)
            {
                if(nodeArray[i] < 0)
                {
                    nodeArray[i] = 0;
                }
            }
        }
    }
    public void Awake()
    {
        hidden1 = new Layer(2, 4);
        hidden2 = new Layer(4, 4);
        output = new Layer(4, 2);
    }

    public float[] Brain(float [] inputs)
    {
        hidden1.Forward(inputs);
        hidden1.Activation();
        hidden2.Forward(hidden1.nodeArray);
        hidden2.Activation();
        output.Forward(hidden2.nodeArray);

        return(output.nodeArray);
    }

    
}