const path = require('path');
const webpack = require('webpack');

const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const HtmlWebPackPlugin = require("html-webpack-plugin");
const CleanWebpackPlugin = require('clean-webpack-plugin');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = (env, argv) => {
	const devMode = argv.mode !== 'production'
	return {
		entry: {
			vendors: './src/web/vendors.js',
			metronic: './src/web/metronic.js',
			main: ['@babel/polyfill', './src/web/index.js']
		},
		output: {
			path: path.resolve('./dist'),
			publicPath: '/'
		},
		module: {
			rules: [{
					test: /\.html$/,
					use: [{
						loader: "html-loader",
						options: {
							minimize: true
						}
					}]
				},
				{
					test: /\.vue$/,
					use: [{
						loader: 'vue-loader',
						options: {}
					}, {
						loader: 'iview-loader',
						options: {
							prefix: true
						}
					}]
				},
				{
					test: /\.js$/,
					exclude: /node_modules/,
					use: {
						loader: "babel-loader"
					}
				},
				{
					test: /\.scss$/,
					use: [
						devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
						'css-loader',
						'postcss-loader',
						'sass-loader',
					]
				},
				{
					test: /\.css$/,
					use: [
						devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
						'css-loader',
						'postcss-loader'
					]
				},
				{
					test: /\.(png|jpg|jpeg|gif)(\?.*)?$/,
					use: [{
						loader: 'file-loader',
						options: { 
							name: 'assets/images/[name].[ext]'
						}
					}]
				},
				{
					test: /\.(woff2?|eot|ttf|otf|svg)(\?.*)?$/,
					use: [{
						loader: 'file-loader',
						options: {
							name: 'assets/fonts/[name].[ext]'
						}
					}]
				}
			]
		},
		plugins: [
			new VueLoaderPlugin(),
			new CleanWebpackPlugin(['dist']),
			new MiniCssExtractPlugin({
				filename: "[name].css",
				chunkFilename: "[id].css"
			}),
			new HtmlWebPackPlugin({
				filename: "index.html",
				template: "./src/web/index.html",
				minify: {
					removeComments: !devMode,
					collapseWhitespace: !devMode
				}
			}),
			new webpack.ProvidePlugin({
				$: 'jquery',
				jQuery: 'jquery',
				jquery: 'jquery',
			})
		],
		devtool: 'cheap-module-eval-source-map',
		devServer: {
			contentBase: path.resolve(__dirname, 'dist'),
			inline: true,
			historyApiFallback: true,
			port: 3000
		},
		resolve: {
			extensions: ['.js', '.vue', '.css'],
			alias: {	
				'vue': 'vue/dist/vue.common.js',							
				'assets': path.resolve(__dirname, './src/web/assets'),
				'metronic': path.resolve(__dirname, './src/web/assets/metronic'),
				'views': path.resolve(__dirname, './src/web/views'),
				'services': path.resolve(__dirname, './src/web/services'),
				'components': path.resolve(__dirname, './src/web/components'),
			}
		}		
	}
}