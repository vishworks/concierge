// index.js

const express = require('express');
const bodyParser = require('body-parser');
const axios = require('axios');

const app = express();
const port = process.env.PORT || 3000;

app.use(bodyParser.json());

const API_KEY = process.env.OPENAI_API_KEY; // Retrieve API key from environment variable

app.post('/generateChatCompletion', async (req, res) => {
  const prompt = req.body.prompt;

  try {
    const response = await axios.post(
      'https://api.openai.com/v1/chat/completions',
      {
        model: 'gpt-3.5-turbo-0125',
        messages: [
          {
            role: 'user',
            content: prompt,
          },
        ],
      },
      {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${API_KEY}`,
        },
      }
    );

    const completion = response.data.choices[0].message.content;
    res.json({ completion });
  } catch (error) {
    console.error('Error generating chat completion:', error.response.data);
    res.status(500).json({ error: 'Failed to generate chat completion' });
  }
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});

