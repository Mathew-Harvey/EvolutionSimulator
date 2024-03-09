using UnityEngine

public class NN: MonoBehaviour
{
    public int [] networkShape = {2,4,4,2}
    public Layer [] layers;
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
        layers = new Layer[networkShape.Length -1];
        for(int 1= 0; int < layers.Length; i++)
        {
            layers[i] = new Layer(networkShape[i], networkShape[i+1]);
        }
    }

    public float[] Brain(float [] inputs)
    {

        hidden1.Forward(inputs);
        hidden1.Activation();
        hidden2.Forward(hidden1.nodeArray);
        hidden2.Activation();
        output.Forward(hidden2.nodeArray);

        for(int i = 0; i < layers.Length; i++)
        {
            if(i == 0)
            {
                layers[i].Forward(inputs);
                layers[i].Activation();
            }
            else if(i == layers.Length - 1)
            {
                layers[i].Forward(layers[i - 1].nodeArray)
            }
            else
            {
                layers[i].Forward(layers[i - 1].nodeArray)
                layers[i].Activation();
            }
            
        }

        return(output.nodeArray);
    }

    
}