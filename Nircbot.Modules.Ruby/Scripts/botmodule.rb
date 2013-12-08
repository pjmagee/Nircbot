class BotModule
	
	attr_accessor :name
	attr_accessor :description
	attr_reader :client
	
	def initialize(client)
		client = client	
	end

	def on_private_message(user, message)
		puts "#{self.class.name} private message"
	end

	def on_public_message(user, channel, message)
		puts "#{self.class.name} public message"
	end

	def on_notice(user, notice)
		puts "#{self.class.name} notice"
	end

	def on_user_joined(user, channel)
		puts "#{self.class.name} user joined"
	end

	def on_user_left(user, channel)
		puts "#{self.class.name} user left"
	end
	
	def send_response(response)
		puts "#{self.class.name} sending response"
		client.send_response(response)
	end
	
end

