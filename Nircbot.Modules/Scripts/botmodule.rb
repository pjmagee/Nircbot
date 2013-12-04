
class BotModule
	
	include System::Diagnostics

	attr_accessor :name
	attr_accessor :description
	
	attr_reader :client

	def initialize(client)
		@client = client		
		Trace.trace_information "I am #{self.class.name}"
	end

	def on_private_message(user, message)

	end

	def on_public_message(user, channel, message)
		
	end

	def on_notice(user, notice)

	end

	def on_user_joined(user, channel)

	end

	def on_user_left(user, channel)

	end

end

