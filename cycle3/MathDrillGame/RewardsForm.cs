using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathDrillGame
{
    public partial class RewardsForm : Form
    {
        public RewardsForm(int coinCount)
        {
            InitializeComponent();

            labelQuantity.Text = "You have gathered " + coinCount + " coins";
            buildRewardsList(coinCount);
            labelNextReward.Text = findNextReward(coinCount) + " coins collected";

        }


        private void buildRewardsList(int coinCount)
        {
            if (coinCount >= 10)
            {
                collected10Label.Visible = collected10Icon.Visible = true;
            }
            if (coinCount >= 25)
            {
                collected25Label.Visible = collected25Icon.Visible = true;
            }
            if (coinCount >= 50)
            {
                collected50Label.Visible = collected50Icon.Visible = true;
            }
            if (coinCount >= 100)
            {
                collected100Label.Visible = collected100Icon.Visible = true;
            }
        }

        private int findNextReward(int coinCount)
        {
            if (coinCount < 10)
                return 10;
            else if (coinCount < 25)
                return 25;
            else if (coinCount < 50)
                return 50;
            else if (coinCount < 100)
                return 100;
            else
            {
                return (coinCount/100 + 1) * 100;
            }
        }
    }
}
