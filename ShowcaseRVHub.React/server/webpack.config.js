const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: './server.js', // Replace with the entry point of your application.
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, './build'), // Replace 'dist' with your desired output directory.
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader', // Use Babel to transpile JavaScript
          options: {
            presets: ['@babel/preset-env'],
          },
        },
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader'], // Load CSS files
      },
      // You can add more rules for handling other file types (e.g., images, fonts).
    ],
  },
  // plugins: [
  //   new HtmlWebpackPlugin({
  //     template: 'src/index.html', // Replace with the path to your HTML template
  //   }),
  // ],
};
